# HOSPITAL MANAGEMENT SYSTEM



This Hospital Management System is designed to assist in managing patient, doctor, and room information within a hospital. It provides functionalities to add, update, and delete records for patients, doctors, and rooms, ensuring efficient management of hospital resources.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Requirements](#requirements)
- [Installation](#installation)
- [Usage](#usage)
- [Structure](#structure)
- [Contributing](#contributing)
- [License](#license)

## Introduction

The HOSPITAL MANAGEMENT SYSTEM is a software application developed to streamline the management of essential components within a hospital environment. It includes modules for patients, doctors, and rooms, allowing for efficient tracking and updating of information.

## Features

- **Patient Module**: Add, update, and delete patient records.
- **Doctor Module**: Manage doctor information, including specialties.
- **Room Module**: Keep track of hospital rooms, including room numbers and types.

## Requirements

- .NET Core SDK
- Entity Framework Core
- Microsoft SQL Server (or another compatible database)

## Installation

1. Clone the repository to your local machine:

   ```bash
   git clone git@github.com:leonTech254/HOSPITAL_MANAGEMENT_SYSTEM.git
   ```

2. Navigate to the project directory:

   ```bash
   cd HOSPITAL_MANAGEMENT_SYSTEM
   ```

3. Build the project:

   ```bash
   dotnet build
   ```

4. Update the database:

   ```bash
   dotnet ef database update
   ```

## Usage

1. Run the application:

   ```bash
   dotnet run
   ```

2. Follow the on-screen instructions to navigate through the menu and perform desired operations.

## Structure

- **Models**: Contains classes representing entities (Patient, Doctor, Room).
- **DatabaseConnection**: Manages the database connection and includes the DBContext class.
- **Services**: Includes service classes for patients, doctors, and rooms, each with relevant functionalities.
- **Program.cs**: Entry point of the application.

## Contributing

Contributions are welcome! Feel free to open issues or submit pull requests to improve the system.

1. Fork the repository.
2. Create a new branch: `git checkout -b feature/new-feature`.
3. Make your changes and commit them: `git commit -m 'Add new feature'`.
4. Push to the branch: `git push origin feature/new-feature`.
5. Submit a pull request.
