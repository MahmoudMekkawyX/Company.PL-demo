# 📖 Project Overview  
**Company.PL** is a layered ASP.NET Core MVC application designed using the **N-Tier Architecture** pattern.  
The solution separates responsibilities into three main layers: **Presentation Layer (PL)**, **Business Logic Layer (BLL)**, and **Data Access Layer (DAL)**.  

This design ensures **separation of concerns**, making the application easier to maintain, extend, and test.  

---

# 🏗️ Repository Structure  

| Layer | Folder(s) | Purpose |
|-------|-----------|---------|
| **Presentation Layer (PL)** | `Company.PL` | Implements the MVC pattern. Contains controllers (`DepartmentController`, `EmployeeController`, `HomeController`), views (Razor pages for CRUD operations), and static assets (`wwwroot`). Responsible for handling user interaction and exposing endpoints. |
| **Business Logic Layer (BLL)** | `Company.BLL` | Includes DTOs (e.g., `DepartmentDto`, `EmployeeDto`), factories, mapping profiles, and services (`DepartmentServices`, `EmployeeServices`). Encapsulates business rules, validation, and application logic. |
| **Data Access Layer (DAL)** | `Company.DAL` | Implements persistence with EF Core (`ApplicationDbContext`, configurations, migrations). Contains domain models (`Department`, `Employee`, `BaseEntity`, enums like `EmployeeType`, `Gender`) and repositories (`DepartmentRepo`, `EmployeeRepo`, `GenericsRepo`). Responsible for database operations. |

---

# ✨ Key Features  

- **Department & Employee Management**: CRUD operations with controllers and Razor views.  
- **DTOs & Mapping**: Clean separation between domain entities and presentation models using AutoMapper.  
- **Repositories**: Generic and specific repositories for data access.  
- **EF Core Persistence**: Configurations, migrations, and DbContext for relational mapping.  
- **MVC Pattern**: Presentation layer follows ASP.NET Core MVC principles for structured UI and controller logic.  
- **Separation of Concerns**: Each layer has a dedicated responsibility, following N-Tier principles.  

---

# 🚀 Future Improvements  

- Add authentication & role-based access.  
- Implement reporting & analytics.  
- Enhance UI with modern front-end frameworks.  
- Extend services for advanced business logic.

## 👨‍💻 Author  
Developed by **Mahmoud Essam Mekkawy**  
