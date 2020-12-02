# FinRust.Api

FinRust is a sample application built using ASP.NET Core and Entity Framework Core. 

### Prerequisites

You will need the following tools:

* [Visual Studio Code or Visual Studio 2019](https://visualstudio.microsoft.com/vs/) (version 16.3 or later)
* [.NET Core SDK 3](https://dotnet.microsoft.com/download/dotnet-core/3.0)

### Setup

Follow these steps to get your development environment set up:

  1. Clone the repository
  2. At the root directory, restore required packages by running:
      ```
     dotnet restore
     ```
  3. Next, build the solution by running:
     ```
     dotnet build
     ```
  4. Within the `\Src\WebUI` directory, launch the back end by running:
     ```
	 dotnet run
	 ```
  5. Launch [https://localhost:44376/api](http://localhost:44376/api) in your browser to view the API

## Technologies

* .NET Core 3
* ASP.NET Core 3
* Entity Framework Core 3