﻿# Finance_API
## Overview
Finance API is a RESTful API developed using .NET for financial management. It provides endpoints to manage budgets, categories, and transactions. The API uses FluentValidation for data validation and PostgreSQL as the database, running on Docker.

## Technologies Used
- .NET
- FluentValidation
- PostgreSQL
- Docker
- Swagger (for API documentation)

## Installation

### Prerequisites
- .NET SDK installed
- Docker installed and running

### Setup
1. Clone the repository:
   ```sh
   git clone <repository-url>
   cd finance-api
   ```
2. Build and run the PostgreSQL database using Docker:
   ```sh
   docker-compose up -d
   ```
3. Run the application:
   ```sh
   dotnet run
   ```
   
## API Endpoints
### Budget
- `GET /api/Budget` - Retrieve all budgets
- `POST /api/Budget` - Create a new budget
- `PUT /api/Budget` - Update an existing budget
- `GET /api/Budget/{id}` - Retrieve a budget by ID

### Category
- `GET /api/Category` - Retrieve all categories
- `POST /api/Category` - Create a new category
- `GET /api/Category/{id}` - Retrieve a category by ID
