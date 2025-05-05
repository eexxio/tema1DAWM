# 🎬 MovieLib

A .NET API for managing movies and reviews.

## 📋 Project Overview

MovieLib is a web API that allows users to access information about movies and their associated reviews. This project is built using .NET 9.0 and follows clean architecture principles, separating concerns into multiple layers.

## 🏗️ Architecture

The solution is organized into four main projects:

1. **MovieLib.Core** - Contains domain entities, interfaces, and DTOs
2. **MovieLib.Database** - Handles data persistence with Entity Framework Core
3. **MovieLib.Infrastructure** - Implements services and business logic
4. **MovieLib.Api** - Exposes REST endpoints for client consumption

## ✨ Features

- 📚 Get all movies with their reviews
- 🔍 Get a specific movie with its reviews by ID
- 🌱 Automatic database seeding with sample movies and reviews
- 📝 Swagger documentation

## 🛠️ Technologies Used

- 🔷 .NET 9.0
- 🗃️ Entity Framework Core 9.0
- 💾 SQL Server
- 📘 Swagger/OpenAPI

## 🚀 Getting Started

### 📋 Prerequisites

- .NET 9.0 SDK or later
- SQL Server (Local or Express)
- Visual Studio 2022 or preferred IDE

### 🗄️ Database Setup

The application uses Entity Framework Core migrations to set up and seed the database:

1. The connection string is configured in `appsettings.json` to use a local SQL Server instance.
2. When the application first runs, it automatically applies any pending migrations and seeds the database with sample data.

### ▶️ Running the Application

1. Clone the repository
2. Navigate to the solution folder
3. Build the solution:
   ```
   dotnet build
   ```
4. Run the API:
   ```
   cd MovieLib.Api
   dotnet run
   ```
5. The API will be available at:
   - 🌐 HTTP: http://localhost:5204
   - 🔒 HTTPS: https://localhost:7089

## 🔌 API Endpoints

- **GET /api/movies** - Retrieve all movies with their reviews
- **GET /api/movies/{id}** - Retrieve a specific movie with its reviews by ID

## 📁 Project Structure

- **MovieLib.Core** 📌
  - Entities (Movie, Review)
  - Interfaces (IMovieRepository, IMovieService)
  - DTOs (MovieDto, ReviewDto, MovieWithReviewsDto)

- **MovieLib.Database** 💾
  - ApplicationDbContext
  - Repositories (MovieRepository)
  - Migrations
  - DataSeeder

- **MovieLib.Infrastructure** ⚙️
  - Services (MovieService)

- **MovieLib.Api** 🌐
  - Controllers (MoviesController)
  - Program.cs (Configuration and DI setup)

## 📄 License

This project is licensed under the MIT License.