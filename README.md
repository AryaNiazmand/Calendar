
## Prerequisites
- [.Net 5 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
- [Angular 13](https://www.c-sharpcorner.com/article/how-to-setup-and-install-angular-13/)
- You need Visual Studio 16.8 or later to use .NET 5.0 on Windows. On macOS, you need the latest version of Visual Studio for Mac. The C# extension for Visual Studio Code supports .NET 5.0 and C# 9.
## Run Locally
Clone the project

```bash
  git clone https://github.com/mohammad-niazmand/Calendar.git
```

Go to the project directory

```bash
  cd Calendar
```

Install Backend app dependencies

```bash
  dotnet build
```

Start Backend app

```bash
  dotnet run --project Calendar.API 
```
  Note: Make sure that it runs on port 5000
  
Go to the UI app directory

```bash
  cd Calendar.SPA
```
Install angular app dependencies

```bash   
   npm install
```
Start angular app

```bash
 ng serve 
```
 browse http://localhost:4200/ 
## Running Tests

To run tests, run the following command

Go to the project directory

```bash
  cd Calendar
  dotnet test
```


