using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Kutuphane.Service
{
    public class GeminiAiClient
    {
        private readonly string _apiKey;
        private readonly string _modelName;

        public GeminiAiClient()
        {
            _apiKey = ConfigurationManager.AppSettings["GEMINI_API_KEY"];
            _modelName = ConfigurationManager.AppSettings["GEMINI_MODEL"];

            if (string.IsNullOrWhiteSpace(_modelName))
                _modelName = "gemini-pro"; // ✅ default

            if (string.IsNullOrWhiteSpace(_apiKey))
                throw new Exception("GEMINI_API_KEY App.config içinde yok.");
        }

        /// <summary>
        /// Prompt gönderir, Gemini'den sadece JSON array (ID listesi) bekler.
        /// Örn: [12,45,3,9,88]
        /// </summary>
        public async Task<List<int>> OneriIdleriGetirAsync(string prompt)
        {
            string url =
                $"https://generativelanguage.googleapis.com/v1beta/models/{_modelName}:generateContent?key={_apiKey}";

            using (HttpClient http = new HttpClient())
            {
                http.Timeout = TimeSpan.FromSeconds(25);

                var body = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new[]
                            {
                                new { text = prompt }
                            }
                        }
                    },
                    generationConfig = new
                    {
                        temperature = 0.3,
                        maxOutputTokens = 256
                    }
                };

                string json = JsonSerializer.Serialize(body);

                using (var resp = await http.PostAsync(
                    url,
                    new StringContent(json, Encoding.UTF8, "application/json")))
                {
                    string respText = await resp.Content.ReadAsStringAsync();

                    if (!resp.IsSuccessStatusCode)
                        throw new Exception("Gemini API hata: " + resp.StatusCode + "\n" + respText);

                    // candidates[0].content.parts[0].text
                    string modelText = ExtractModelText(respText);

                    if (string.IsNullOrWhiteSpace(modelText))
                        return new List<int>();

                    modelText = CleanFence(modelText);

                    // 1) JSON array parse etmeyi dene: [1,2,3]
                    var ids = TryParseIntJsonArray(modelText);
                    if (ids.Count > 0) return ids;

                    // 2) Değilse: metinden sayı çek (fallback)
                    return ExtractIntsByRegex(modelText);
                }
            }
        }

        private string ExtractModelText(string respText)
        {
            try
            {
                using (JsonDocument doc = JsonDocument.Parse(respText))
                {
                    var root = doc.RootElement;

                    if (!root.TryGetProperty("candidates", out JsonElement candidates) ||
                        candidates.ValueKind != JsonValueKind.Array ||
                        candidates.GetArrayLength() == 0)
                        return null;

                    var cand0 = candidates[0];

                    if (!cand0.TryGetProperty("content", out JsonElement content))
                        return null;

                    if (!content.TryGetProperty("parts", out JsonElement parts) ||
                        parts.ValueKind != JsonValueKind.Array ||
                        parts.GetArrayLength() == 0)
                        return null;

                    var part0 = parts[0];

                    if (part0.TryGetProperty("text", out JsonElement textEl))
                        return textEl.GetString();

                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        // ```json ... ``` gibi fence'leri temizler
        private string CleanFence(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return text;

            text = text.Trim();
            text = Regex.Replace(text, @"^\s*```json\s*", "", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"^\s*```\s*", "", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"\s*```\s*$", "", RegexOptions.IgnoreCase);
            return text.Trim();
        }

        private List<int> TryParseIntJsonArray(string maybeJson)
        {
            var list = new List<int>();
            try
            {
                using (JsonDocument doc = JsonDocument.Parse(maybeJson))
                {
                    if (doc.RootElement.ValueKind != JsonValueKind.Array)
                        return list;

                    foreach (var item in doc.RootElement.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Number && item.TryGetInt32(out int v))
                            list.Add(v);
                        else if (item.ValueKind == JsonValueKind.String && int.TryParse(item.GetString(), out int vs))
                            list.Add(vs);
                    }
                }
            }
            catch
            {
                // json değilse boş döner
            }

            // tekrarları temizle
            var uniq = new List<int>();
            foreach (var id in list)
                if (!uniq.Contains(id)) uniq.Add(id);

            return uniq;
        }

        private List<int> ExtractIntsByRegex(string text)
        {
            var list = new List<int>();
            if (string.IsNullOrWhiteSpace(text)) return list;

            // En az 1 haneli tüm sayıları çek
            var matches = Regex.Matches(text, @"\d+");
            foreach (Match m in matches)
            {
                if (int.TryParse(m.Value, out int v))
                {
                    if (!list.Contains(v))
                        list.Add(v);
                }
            }
            return list;
        }
    }
}
