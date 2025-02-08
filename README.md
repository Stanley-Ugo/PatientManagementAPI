# Patient Management API
A Clean Architecture and CQRS-based .NET API for managing patients and their records. This project demonstrates best practices for building scalable, maintainable, and testable applications.

# Features
# CRUD Operations:

Create, retrieve, update, and soft-delete patients.

Create, retrieve, update, and delete patient records.

# Clean Architecture:

Separation of concerns into Api, Application, Domain, and Infrastructure layers.

# CQRS Pattern:

Commands for write operations (e.g., create, update, delete).

Queries for read operations (e.g., get by ID, get all).

# SQLite Database:

Lightweight, in-memory database for data persistence.

# Swagger Documentation:

Interactive API documentation for easy testing and exploration.

# Docker Support:

Containerized application for easy deployment.

# Project Structure
The project is organized into four layers following Clean Architecture principles:

# Api:

Contains controllers and API endpoints.

Acts as the entry point for the application.

# Application:

Implements business logic and use cases.

Uses MediatR for CQRS (Commands and Queries).

# Core:

Contains core entities and repository interfaces.

Represents the business rules and domain logic.

# Infrastructure:

Handles data access and external services.

Implements repositories and database context.

# Key Design Decisions
1. Clean Architecture

Why?

Ensures separation of concerns and independence of layers.

Makes the application easier to maintain, test, and scale.

# Implementation:

Core layer is independent of other layers.

Application layer depends only on the Domain layer.

Infrastructure layer implements domain interfaces (e.g., repositories).

Api layer depends on Application and Infrastructure layers.

2. CQRS Pattern

Why?

Separates read and write operations for better scalability and maintainability.

Simplifies complex business logic by isolating commands and queries.

# Implementation:

Commands (e.g., CreatePatientCommand, UpdatePatientCommand) handle write operations.

Queries (e.g., GetPatientByIdQuery, GetAllPatientsQuery) handle read operations.

MediatR is used to dispatch commands and queries.

3. Soft Delete
Why?

Preserves historical data by marking records as deleted instead of physically removing them.

Useful for auditing and recovery purposes.

# Implementation:

Added an IsDeleted flag to the Patient entity.

Soft delete is implemented in the repository by setting IsDeleted to true.

4. SQLite Database
Why?

Lightweight and easy to set up for development and testing.

Supports in-memory databases for fast execution.

# Implementation:

Used Entity Framework Core with SQLite for data persistence.

Database context and migrations are configured in the Infrastructure layer.

5. Swagger Documentation
Why?

Provides interactive API documentation for developers.

Simplifies testing and exploration of API endpoints.

# Implementation:

Integrated Swagger using the Swashbuckle.AspNetCore package.

Enabled Swagger UI in the Program.cs file.

6. Docker Support
Why?

Simplifies deployment and ensures consistency across environments.

Makes the application portable and easy to run in any environment.

# Implementation:

Added a Dockerfile to containerize the application.

Used multi-stage builds to optimize the Docker image size.

Setup and Run
Prerequisites
.NET * SDK

Docker (optional)

Steps
Clone the repository:

bash
Copy
git clone https://github.com/Stanley-Ugo/PatientManagementAPI.git
cd PatientManagementAPI
Restore dependencies:

bash
Copy
dotnet restore
Run database migrations:

bash
Copy
dotnet ef database update
Run the application:

bash
Copy
dotnet run
Access the API:

Swagger UI: http://localhost:5000/swagger

API Endpoint: http://localhost:5000/api/patients

Run with Docker
Build the Docker image:

bash
Copy
docker build -t patientmanagementapi .
Run the Docker container:

bash
Copy
docker run -p 8080:80 patientmanagementapi
Access the API:

Swagger UI: http://localhost:8080/swagger

API Endpoint: http://localhost:8080/api/patients

Testing
Unit tests are written using xUnit and Moq.

Run tests using:

bash
Copy
dotnet test
