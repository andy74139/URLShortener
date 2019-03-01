# Environment
- Operating System: Microsoft Windows 10
- Framework: .NET Core Framework, MVC
- Database: MS SQL Server 2008 R2

# How to use it
1. Setup the environment, you need SQL Server, .NET Core SDK, and .NET Core runtime
2. Build the solution, and publish and execution files
3. Run the application

## How to setup
- Install MS SQL Server, with instance name "CCWL", and create a database named "PicCollage_URLShortener"
- Download and install .NET Core SDK & Runtime with version 2.1 (or newer version) [here](https://dotnet.microsoft.com/download)

## How to build & publish
- Use command line `dotnet publish .\URLShortener.sln`

## How to run
- In the Use command line to execute `dotnet .\URLShortener\bin\Debug\netcoreapp2.1\publish\URLShortener.dll`
- The server will be started and listening



