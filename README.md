# About Task Tracking

This project is a simple but powerful web application to manage tasks.

## Features

- CRUD Operations.
- REST API.
- Repository Pattern.
- Code First.
- Domain-Drive Design
- Entity Framework

## Requirements

- A Windows OS
- .NET Core 3.1 or superior
- SQL Server Express 2016 or superior

## Built With

- Angular
- .NET Core
- SQL Server Express
- Bootstrap
- Entity Framework

## Set up

1 - Clone this project running `git clone https://github.com/RayMaroun/Task-Tracking-Angular-Asp.Net-Core.git` in your terminal. If you haven't git installed can simply download it and unzip it.

2 - Go to the "TaskTrackingAPI" project and build it to restore the missing packages.

3 - Prepare the database

 *  Go to your Microsoft SQL Server Management Studio and build an empty database with the name "TaskDB".
 *  Go to the "appsettings.json" file and update the connection string accordingly.
 *  Go to your "TaskTrackingAPI" project and run in the Package Manager Console `Update-Database` to run the migration and create the tables.

4 - Navigate then using the command line to the "TaskTracking" project and use `npm install` in order to install missing packages.

5 - Run the command `ng serve` to run the angular project.

6 - Start testing.

### Future work

> Improve the design.

> Adding authentication and authorization.