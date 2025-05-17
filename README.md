# DevSpot

**DevSpot** is an ASP.NET Core web application for job announcements with role-based access control.  
It uses ASP.NET Core Identity for authentication and authorization, and Entity Framework Core for database operations.  
The system supports three roles: **Admin**, **Employer**, and **JobSeeker**.

---

## Features

- Role-based access using ASP.NET Core Identity  
- Employers can post and manage their own job announcements  
- JobSeekers can view announcements from Employers  
- Admins have full control over all data and operations  
- Core business logic covered with XUnit tests  

---

## User Roles and Permissions

### Admin
- Can create, read, update, and delete any announcement  
- Has full access to all system features  

### Employer
- Can create, update, and delete their own announcements  
- Cannot access or modify announcements from other employers  

### JobSeeker
- Can only view announcements  
- Cannot create, update, or delete any content  

---

## Technology Stack

- ASP.NET Core  
- ASP.NET Core Identity  
- Entity Framework Core  
- ASP.NET Core MVC  
- ASP.NET Core Web API  
- XUnit (for unit testing)  
