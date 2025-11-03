# MyProject

This is a C# project named **MyProject**. 

## Overview

MyProject is designed to demonstrate a simple structure for a C# application, including a main application and a corresponding test project.

## Project Structure

```
MyProject
├── src
│   ├── Program.cs
│   ├── MyProject.csproj
│   └── Models
│       └── Class1.cs
├── tests
│   ├── MyProject.Tests.csproj
│   └── UnitTest1.cs
├── .gitignore
├── MyProject.sln
└── README.md
```

## Getting Started

To build and run the application, follow these steps:

1. Open the project in your preferred IDE.
2. Restore the project dependencies:
   ```
   dotnet restore
   ```
3. Build the project:
   ```
   dotnet build
   ```
4. Run the application:
   ```
   dotnet run --project src/MyProject.csproj
   ```

## Running Tests

To run the unit tests, navigate to the tests directory and execute:
```
dotnet test
```

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue for any suggestions or improvements.

## License

This project is licensed under the MIT License. See the LICENSE file for details.