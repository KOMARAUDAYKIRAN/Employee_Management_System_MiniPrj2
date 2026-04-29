# Employee Management System (Mini Project 2)

##  Overview
The **Employee Management System** is a full-stack web application developed as part of Mini Project 2. It extends the frontend dashboard into a complete enterprise-grade solution using a **.NET 8 Web API backend**, **SQL Server 2022**, and **Entity Framework Core (Code First)**.

This application allows organizations to manage employee records with secure authentication, role-based access control, and efficient server-side operations.

---

## Features

### Authentication & Authorization
- User Registration & Login
- BCrypt password hashing
- JWT-based authentication
- Role-based access:
  - **Admin** → Full CRUD access
  - **Viewer** → Read-only access

### Employee Management
- Add, Edit, Delete employees (Admin only)
- View employee details
- Server-side validation

### Dashboard
- Total Employees
- Active / Inactive count
- Department-wise distribution
- Recent employees

### Advanced Features
- Server-side Search
- Filtering (Department, Status)
- Sorting (Name, Salary, Join Date)
- Pagination (SQL-based)

### API Documentation
- Swagger / OpenAPI support

---

## Tech Stack

### Backend
- .NET 8 Web API
- Entity Framework Core (Code First)
- SQL Server 2022
- JWT Authentication
- BCrypt.Net-Next

### Frontend
- HTML5, CSS3, Bootstrap 5
- JavaScript (ES6+)
- jQuery

### Testing
- NUnit
- Moq
- EF Core In-Memory

---

## Project Structure
```bash

EMS-MiniProject2/ 
│ 
├── EMS.API/                         ← .NET 8 Web API 
│   ├── Controllers/ 
│   │   ├── EmployeesController.cs  ← CRUD + /dashboard + pagination 
│   │   └── AuthController.cs       ← /auth/register + /auth/login 
│   ├── Data/ 
│   │   └── AppDbContext.cs         ← EF Core DbContext + seed data 
│   ├── DTOs/ 
│   │   └── EmployeeDtos.cs         ← request/response/paged DTOs 
│   ├ 
│   ├── appsettings.json            ← connection string + JWT config 
│   ├── Models/ 
│   │   ├── Employee.cs 
│   │   └── AppUser.cs 
│   ├── Services/ 
│   │   ├── EmployeeService.cs      ← Server-side filter/sort/pagination 
├   │   ├── IEmployeeRepository.cs  ← Data access contract (interface) 
├   │   ├── EmployeeRepository.cs   ← Data Access Interface Implementation    
│   │   └── AuthService.cs          ← BCrypt hashing + role management=JWT    
│   ├── appsettings.json            ← SQL Server connection string 
│   ├── Program.cs                  ← DI, CORS, Swagger,JWT Authentication 
│   └── EMS.API.csproj 
│ 
└── frontend/                        ← Updated frontend from Mini Project 1 
    ├── index.html 
    ├── css/styles.css 
    └── js/ 
        ├── config.js               ← NEW: API_BASE_URL constant 
        ├── storageService.js       ← REPLACED: real fetch() API calls 
        ├── authService.js          ← UPDATED: calls /api/auth/* 
        ├── employeeService.js      ← UPDATED: async delegates 
        ├── validationService.js    ← MINOR: added mapServerErrors() 
        ├── dashboardService.js     ← UPDATED: single API call 
        ├── uiService.js            ← UPDATED: pagination + role UI 
        └── app.js                  ← UPDATED: async/await + pagination state
```
---

## Setup Instructions

### ✅ Prerequisites
- .NET SDK 8.0+
- SQL Server 2022
- VS Code / Visual Studio

---

### Backend Setup

```bash
Navigate to API folder:
cd EMS.API
Install dependencies:
dotnet restore
Configure database in appsettings.json:
"DefaultConnection": "Server=localhost;Database=EMSDashboard;Trusted_Connection=True;TrustServerCertificate=True;"
Run migrations:
dotnet ef database update
Run API:
dotnet run
Open Swagger:
http://localhost:5000/swagger

```
---
## 🌐 Frontend Setup

- Open `frontend/index.html` using **Live Server**  
  **OR**  
- Open the file directly in your browser  

---

## Default Credentials

| Role   | Username | Password   |
|--------|----------|------------|
| Admin  | admin    | admin123   |
| Viewer | viewer   | viewer123  |

---

## API Endpoints

### Authentication
- `POST /api/auth/register`
- `POST /api/auth/login`

### Employees
- `GET /api/employees`
- `GET /api/employees/{id}`
- `POST /api/employees` *(Admin only)*
- `PUT /api/employees/{id}` *(Admin only)*
- `DELETE /api/employees/{id}` *(Admin only)*

---

## Security Features
- JWT-based Authentication
- Role-based Authorization (Admin / Viewer)
- BCrypt password hashing

---

## Testing

Run backend tests:

```bash
dotnet test
```
### Author

Name: Uday Kiran Komara
Batch: Batch 7
---

### Notes
Run dotnet ef database update before starting API
JWT is stored in memory (not localStorage)
Ensure SQL Server is running
---
### Conclusion

This project demonstrates a full-stack Employee Management System with modern architecture, secure authentication, and scalable backend design.
