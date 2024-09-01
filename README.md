Welcome to the ASP.NET Core MVC Master-Details Example repository! This project provides a practical implementation of the master-detail pattern using ASP.NET Core MVC. It is designed to help you understand how to create and manage related data efficiently in a web application.

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Folder Structure](#folder-structure)
- [Contributing](#contributing)
- [License](#license)

## Project Overview

The Master-Details pattern is a common design for applications where you need to display a list of items (the master) and show detailed information for each selected item (the details). This repository demonstrates how to implement this pattern using ASP.NET Core MVC, showcasing a clean separation of concerns between the UI, business logic, and data access layers.

## Features

- **Master-Detail Interface**: 
  - **Master List**: Display a list of items (e.g., `Products` or `Categories`) with basic CRUD operations.
  - **Detail View**: View and edit detailed information of a selected item, with data validation and interaction capabilities.

- **CRUD Operations**: 
  - **Create**: Add new master items and details.
  - **Read**: View a list of items and their details.
  - **Update**: Modify existing items and details.
  - **Delete**: Remove items and associated details.

- **Data Validation**: 
  - Server-side validation for data consistency and accuracy.
  - Form validation messages to provide feedback to users.

- **Responsive UI**: 
  - Built using Bootstrap for a clean, responsive design.
  - User-friendly interface for managing data effectively.

- **Search and Filtering**: 
  - Options to search and filter the master list to find specific items quickly.

- **Error Handling**: 
  - Graceful error handling and user notifications for operations.

- **Entity Framework Core**: 
  - Uses EF Core for data access, including database migrations and context management.

## Prerequisites

Ensure you have the following installed before starting:

- [.NET 6.0 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/) or another preferred code editor
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or a compatible database provider

## Installation

1. **Clone the Repository**

   ```bash
   git clone https://github.com/TausifImtiaz/AspDotNetCoreMVC_MasterDetails.git
   cd AspDotNetCoreMVC_MasterDetails
   ```

2. **Restore Dependencies**

   Navigate to the project directory and restore the NuGet packages:

   ```bash
   dotnet restore
   ```

3. **Update Database**

   Apply the Entity Framework Core migrations to set up the database:

   ```bash
   dotnet ef database update
   ```

4. **Run the Application**

   Start the application using:

   ```bash
   dotnet run
   ```

   Alternatively, you can use Visual Studio by pressing `F5` or `Ctrl + F5` to run the application.

## Usage

After running the application, you can access it via `http://localhost:5000` or the URL provided by your development server.

- **Master List**: Navigate to `/Items` to view and manage the list of master items.
- **Item Details**: Select an item from the master list to view or edit its details.

## Folder Structure

The project follows a standard ASP.NET Core MVC structure:

- **`Controllers/`**: Contains controllers that handle incoming requests and responses.
- **`Models/`**: Contains data models and business logic.
- **`Views/`**: Contains Razor views that render HTML content.
- **`Data/`**: Contains the database context and migration files.
- **`wwwroot/`**: Contains static files like CSS, JavaScript, and images.

## Contributing

We welcome contributions to this project! If you have any suggestions, bug reports, or feature requests, please open an issue or submit a pull request. Please follow these steps to contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature/your-feature`).
5. Open a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

Thank you for checking out this repository! If you have any questions or need further assistance, feel free to reach out.
