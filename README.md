# 🏢 IT Department Management System

A web-based IT Department Management System built with **ASP.NET Core MVC**, **Entity Framework Core**, and **SQL Server** following the **Repository Pattern** and a layered architecture.

The system enables IT departments to manage device categories, devices, custom properties, and property values through a clean and scalable administration interface.

---

## ✨ Features

- 📁 Manage Device Categories
  - Create
  - Edit
  - Delete
  - View Categories

- 💻 Manage Devices
  - Add new devices
  - Update device information
  - Delete devices
  - View all devices

- 🏷️ Manage Property Items
  - Create custom properties
  - Edit property names
  - Delete properties

- 🔗 Category Properties
  - Assign multiple properties to each device category
  - Flexible category-property relationships

- 📌 Device Property Values
  - Store dynamic property values for every device
  - Supports category-specific attributes

- 🗄 SQL Server Database
- ⚡ Entity Framework Core
- 🏛 Repository Pattern
- 🧩 Layered Architecture (Presentation, Business Logic, Data Access)

---

# 🏗 Architecture

The project follows a multi-layer architecture:

```
IT Department Solution
│
├── IT.PL      → Presentation Layer (MVC)
├── IT.BLL     → Business Logic Layer
└── IT.DAL     → Data Access Layer
```

This architecture improves:

- Separation of Concerns
- Maintainability
- Scalability
- Testability

---

# 🛠 Technologies Used

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- LINQ
- HTML5
- CSS3
- Bootstrap
- Razor Views
- Dependency Injection

---

# 📂 Database Structure

Main entities include:

- Device
- DeviceCategory
- PropertyItem
- CategoryProperty
- DevicePropertyValue

Relationships are implemented using Entity Framework Core.

---

# 🚀 Getting Started

## Clone the repository

```bash
git clone https://github.com/BaherElgobashi/IT-Department.git
```

## Navigate to the project

```bash
cd IT-Department
```

## Restore packages

```bash
dotnet restore
```

## Update the connection string

Open:

```
appsettings.json
```

Update:

```json
"ConnectionStrings": {
  "DefaultConnection": "Your SQL Server Connection String"
}
```

---

## Apply Migrations

```bash
dotnet ef database update
```

---

## Run the application

```bash
dotnet run
```

or press **F5** in Visual Studio.

---

# 📸 Screenshots

> Add screenshots of the following pages:

- Dashboard
- Device Categories
- Devices
- Property Items
- Create Device
- Edit Device

---

# 📁 Project Structure

```
IT.PL
│
├── Controllers
├── Views
├── ViewModels
├── wwwroot
│
IT.BLL
│
└── ViewModels
│
IT.DAL
│
├── Data
├── Entities
├── Repositories
└── Migrations
```

---

# 📖 Design Patterns

- Repository Pattern
- Dependency Injection
- MVC Pattern

---

# 🎯 Future Improvements

- Authentication & Authorization
- Role-based Access Control
- Search & Filtering
- Pagination
- Dashboard Statistics
- Image Upload
- REST API
- Unit Testing
- Logging
- Audit Trail

---

# 👨‍💻 Author

**Baher Mohamed Zakaria Elgobashi**

- GitHub: https://github.com/BaherElgobashi
- LinkedIn: https://www.linkedin.com/in/baher-elgobashi-1975a5298

---

# ⭐ If you like this project

Please consider giving it a **Star ⭐** on GitHub.
