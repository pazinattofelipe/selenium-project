# Selenium Project

## Overview

This is a Selenium WebDriver automation testing project built with C# and NUnit. The project contains automated tests for web functionality, including:

- **PDF File Upload Tests**: Validates file upload functionality on web pages, supporting PDF, JPG, and XLS files

The project uses Selenium WebDriver to automate browser interactions and NUnit as the testing framework.

## Prerequisites

### .NET Installation

This project requires the latest version of .NET. Download and install it from:

**[Download .NET](https://dotnet.microsoft.com/en-us/download)**

### System Requirements

- Windows, macOS, or Linux
- .NET 10.0 or later
- Chrome browser (for ChromeDriver)

## Getting Started

### Clone or Extract the Repository

```bash
git clone <repository-url>
cd selenium-project
```

### Build the Project

Compile the project and restore dependencies using the .NET CLI:

```bash
dotnet build
```

This command will:
- Restore NuGet packages
- Compile the C# code
- Download and configure ChromeDriver

### Run Tests

Execute the test suite using the following command:

```bash
dotnet test
```

This command will run all tests in the project and display the results in your console.

### Run Specific Tests

To run a specific test class:

```bash
dotnet test --filter "ClassName=PdfFileUpload"
```

## Project Structure

```
SeleniumProject/
├── pages/              # Page Object Models (POM)
│   ├── UploadPage.cs
├── tests/              # Test Classes
│   ├── BaseClass.cs
│   ├── PdfFileUpload.cs
├── data/               # Test data files
│   └── valid/          # Valid test files (PDFs, images, etc.)
└── SeleniumProject.csproj
```

## Technologies Used

- **Selenium WebDriver**: v4.41.0 - Browser automation
- **NUnit**: v4.3.2 - Testing framework
- **ChromeDriver**: v146.0 - Chrome browser driver
- **.NET**: 10.0 - Runtime framework

## Notes

- Ensure Chrome browser is installed on your system
- Test data files are located in the `data/valid/` directory
- Screenshots will be captured in the `screenshots/` directory for failed tests
