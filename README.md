# WordForge

**WordForge** is a NY Times-style word-forming game built in C# with a rich WinForms UI. It leverages .NET libraries including NetSpell for real-time word validation, SQL Server for persistent caching, and multithreading for fast, responsive gameplay.

---

## ✨ Features

- 🖥️ **WinForms Interface**: User-friendly, responsive desktop UI.
- ✅ **NetSpell Integration**: Uses the [NetSpell](https://github.com/ericwoodruff/NetSpell) .NET library for accurate, real-time spell checking and word validation.
- 💾 **SQL Server Storage**: Caches word lists, player sessions, and scores using SQL Server.
- ⚡ **LINQ Queries**: Clean, maintainable data access with LINQ for SQL Server.
- 🔄 **Multithreading**: Concurrent processing for validating words and updating scores, ensuring smooth, lag-free gameplay even under heavy use.
- 🗂️ **Caching Strategy**: Uses SQL Server Management Studio-friendly database schemas to store and quickly retrieve valid words and player history.

---

## ⚙️ Technologies Used

- **C# (.NET Framework)**
- **WinForms** for UI
- **NetSpell** for dictionary validation
- **SQL Server** (tested with SQL Server Management Studio)
- **ADO.NET / LINQ** for database interaction
- **System.Threading** for multithreaded logic

---

## 🗃️ Database Design

The game uses SQL Server to cache:

- ✅ Valid words and their scores
- ✅ Player sessions and historical plays
- ✅ Game configurations

SQL Server Management Studio can be used to manage, backup, and inspect the database.

---

## 🚀 How It Works

1️⃣ Player selects letters to form words in a NY Times-style grid.  
2️⃣ Input is validated in real time via **NetSpell**.  
3️⃣ Validated words are scored and stored in SQL Server for reuse and audit.  
4️⃣ Multithreaded validation and scoring ensure low latency even with large word lists.  
5️⃣ Cached results reduce database round-trips on subsequent plays.

---

## 🛠️ Setup Instructions

1. Clone the repo:
   ```bash
   git clone https://github.com/yourusername/wordforge.git
