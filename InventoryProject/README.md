# Inventory Management API

## Overview
This project is a RESTful Web API built using ASP.NET Core and Entity Framework Core.  
It demonstrates clean layered architecture with Controller → Service → Data separation.

The API provides full CRUD operations for managing inventory products with proper validation, async database access, and centralized exception handling.

---

## Tech Stack
- ASP.NET Core Web API (.NET)
- Entity Framework Core (Code First)
- SQL Server (LocalDB)
- Dependency Injection
- Async / Await Programming
- Global Exception Middleware
- Swagger (OpenAPI)

---

## Architecture
Controller → Service Layer → DbContext → Database

- Controllers handle HTTP requests and responses.
- Services contain business logic.
- DbContext handles database operations.
- Global middleware handles unexpected exceptions.

---

## Features
- Create, Read, Update, Delete Products
- Proper HTTP status codes (201, 400, 404, 204)
- ID mismatch validation
- Model validation using DataAnnotations
- Centralized global exception handling
- Async database operations

---

## API Endpoints

### Get All Products
GET /api/inventory

### Get Product By ID
GET /api/inventory/{id}

### Create Product
POST /api/inventory

### Update Product
PUT /api/inventory/{id}

### Delete Product
DELETE /api/inventory/{id}

---

## How to Run
1. Clone the repository
2. Update connection string if needed
3. Run migration:
	Add-Migration InitialCreate
    Update-Database
4.Run the project
5. Use Swagger to test endpoints

---

## Purpose
This project was built to demonstrate backend development practices including clean architecture, dependency injection, async programming, and structured exception handling.