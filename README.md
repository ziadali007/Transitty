# 🚌 City Bus Management System

A full-featured ASP.NET Core Web API designed to manage city-wide public transportation services. This system enables administrators to handle bus routes, schedules, bookings, and employee logistics while providing customers with access to available trips and seat bookings — all secured via JWT-based user authentication.

---

## 🔧 Key Features

- **User Authentication & JWT Security**
  - Secure user registration and login
  - Role-based access control using JWT tokens

- **Route Management**
  - Add, edit, and organize city bus routes with source and destination

- **Bus Management**
  - Register buses with seat capacity
  - Assign buses to specific routes

- **Seat Allocation**
  - Auto-generate seats based on bus capacity
  - Prevent over-allocation of seats

- **Trip Scheduling**
  - Assign buses, drivers, and conductors to scheduled trips
  - Specify trip start and end times

- **Seat Booking System**
  - Customers can view available seats on a trip
  - Book seats with real-time availability checks

- **Bus Stop Management**
  - Add and order bus stops along routes
  - Associate bus stops with routes and timing

- **Employee Management**
  - Manage details for drivers, conductors, and other staff
  - Assign roles and maintain contact information

- **Schedule Tracking**
  - Manage employee shifts and leave records

- **Entity Framework Core Integration**
  - Strong use of relationships and navigation properties
  - Proper foreign key configurations for integrity

- **Generic Repository & Unit of Work**
  - Reusable, scalable service logic
  - Centralized transaction control

- **DTO & AutoMapper Support**
  - Efficient mapping between entities and DTOs
  - Clean data validation and API contracts

- **RESTful API Design**
  - Clean, well-structured endpoints
  - Tested via Postman with real-world JSON examples

---

## 🚀 Technologies Used

- **.NET 8 (ASP.NET Core Web API)**
- **Entity Framework Core**
- **JWT Authentication**
- **AutoMapper**
- **SQL Server**
- **Postman (API testing)**

---

## 📦 Getting Started

1. Clone the repository
2. Update your `appsettings.json` with SQL connection and JWT keys
3. Run migrations:  
   ```bash
   dotnet ef database update
