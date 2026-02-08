<!-- ===================== 1. BANNER ===================== -->
<p align="center">
  <img src="https://capsule-render.vercel.app/api?type=waving&color=0:0f766e,100:14b8a6&height=220&section=header&text=Library%20Automation%20System&fontSize=42&fontColor=ffffff&fontAlignY=35" />
</p>

<!-- ===================== 2. TYPING ANIMATION ===================== -->
<p align="center">
  <img src="https://readme-typing-svg.herokuapp.com?font=Montserrat&size=22&duration=3000&pause=800&color=14B8A6&center=true&vCenter=true&width=700&lines=Modern+Desktop+Library+Management;Student+%26+Staff+Focused+Automation;Statistics%2C+AI+Recommendations+%26+Reporting;Built+with+C%23+and+.NET" />
</p>

<!-- ===================== 3. PROJECT TITLE ===================== -->
<h1 align="center">📚 Library Automation System</h1>

<p align="center">
  A modern, data-driven desktop application for managing library operations efficiently.
</p>

<!-- ===================== 4. BADGES ===================== -->
<p align="center">
  <img src="https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" />
  <img src="https://img.shields.io/badge/Platform-.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/UI-WinForms-0f766e?style=for-the-badge" />
  <img src="https://img.shields.io/badge/Database-SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" />
  <img src="https://img.shields.io/badge/Status-Active%20Development-14b8a6?style=for-the-badge" />
</p>

<!-- ===================== 5. ABOUT THE PROJECT ===================== -->
## 📖 About the Project

**Library Automation System** is a feature-rich **desktop application** designed to digitalize and streamline library operations.  
It provides **student-focused and staff-oriented workflows**, advanced **statistics dashboards**, and **AI-assisted book recommendations**.

The system is built with a **clean layered architecture**, prioritizing performance, usability, and maintainability.  
It is suitable for **academic projects**, **portfolio presentation**, and **real-world small-to-medium libraries**.

<!-- ===================== 6. FEATURES ===================== -->
## ✨ Features

### 👤 User & Access Management
- Student and staff authentication
- Role-based access control
- Secure registration and login flows

### 📚 Book & Inventory Management
- Book CRUD operations
- Author and genre management
- Stock tracking and availability control

### 🔄 Borrowing & Return System
- Book lending and return workflows
- Late return and penalty calculation
- Condition-based return handling

### 📊 Statistics & Analytics
- Total books, users, daily transactions
- Genre distribution (Pie Charts)
- Most borrowed books and authors
- Visual dashboards with DevExpress Charts

### 🤖 AI-Assisted Recommendations
- Genre-based intelligent book suggestions
- Personalized recommendation panel
- User preference awareness

### 🧾 Reports & Outputs
- PDF and Excel export support
- Printable statistics and summaries
- Administrative reporting tools

<!-- ===================== 7. TECH STACK ===================== -->
## 🛠 Tech Stack

<p align="center">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" width="55" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-original.svg" width="55" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/microsoftsqlserver/microsoftsqlserver-plain.svg" width="55" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/windows8/windows8-original.svg" width="55" />
</p>

**Technologies Used**
- **Programming Language:** C#
- **Framework / Platform:** .NET WinForms
- **UI Components:** DevExpress
- **Database:** Microsoft SQL Server
- **Architecture:** Layered (UI / Service / Data Access)

<!-- ===================== 8. INSTALLATION ===================== -->
## 🚀 Installation & Run

1️⃣ Visual Studio must be installed  
(.NET Desktop Development workload required)

2️⃣ Clone the repository:

```bash
git clone https://github.com/cemreeyrtsvr/KutuphaneOtomasyonu.git
```

3️⃣ Open the solution file in Visual Studio

4️⃣ Configure SQL Server connection string if required

5️⃣ Run the application 🚀

---
---

## 🔐 API Configuration (App.config)

To run AI-powered features such as **book recommendations** and **analytics services**, you must provide your own API key.

The project uses an external API integration configured via the **App.config** file.

### 📌 Steps

1️⃣ Open the `App.config` file in the project.

2️⃣ Locate the API key section:

```xml
<appSettings>
  <add key="ApiKey" value="******" />
</appSettings>
```

3️⃣ Replace `******` with your own API key:

```xml
<appSettings>
  <add key="ApiKey" value="YOUR_API_KEY_HERE" />
</appSettings>
```

4️⃣ Save the file and rebuild the project.

⚠️ **Security Note:**  
Never share your API key publicly or upload it to GitHub repositories.

---

## 📊 Dashboard & Statistics Screenshots

Below are static previews of the system’s analytics and reporting interface.

These dashboards provide real-time insights into library operations.

### 📈 General Statistics Panel

- Total books
- Total users
- Daily borrow counts
- Active transactions

<p align="center">
  <img src="screenshots/general_statistics.png" width="700"/>
</p>

---

### 🥧 Genre Distribution Chart

Displays book categories in a pie chart format.

<p align="center">
  <img src="screenshots/genre_distribution.png" width="700"/>
</p>

---

### 📚 Most Borrowed Books

Highlights top-performing books based on lending frequency.

<p align="center">
  <img src="screenshots/most_borrowed_books.png" width="700"/>
</p>

---

### 👤 User Activity Dashboard

Tracks borrowing activity per student/user.

<p align="center">
  <img src="screenshots/user_activity.png" width="700"/>
</p>

---

## 🗂️ Screenshot Folder Structure

Make sure your repo includes this folder:

```
screenshots/
│
├── general_statistics.png
├── genre_distribution.png
├── most_borrowed_books.png
└── user_activity.png
```

You can rename images, but update README paths accordingly.

---


## 🧠 Purpose

This project was developed to:

- Learn layered architecture design  
- Practice SQL Server database integration  
- Build real-world desktop automation systems  
- Implement reporting and analytics dashboards  
- Explore AI-based recommendation logic  

---

## 👩‍💻 Developer

**Cemre Yurtsever**

🎓 Software Engineering Student  
💻 Java • C# • Python  
🤖 AI & Data Science Enthusiast  

📫 Contact:

<p align="left">
  <a href="https://www.linkedin.com/in/cemre-yurtsever">
    <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/linkedin/linkedin-original.svg" height="35"/>
  </a>
  <a href="mailto:cyurtsever64@gmail.com">
    <img src="https://cdn-icons-png.flaticon.com/512/732/732200.png" height="35"/>
  </a>
</p>

---

⭐ If you find this repository useful, don’t forget to star it!

<p align="center">
  <img src="https://capsule-render.vercel.app/api?type=waving&color=0:14b8a6,100:0f766e&height=120&section=footer"/>
</p>
