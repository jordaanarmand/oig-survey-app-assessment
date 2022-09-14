# List of migration commands

## 0. Install Tools
```
dotnet tool install --global dotnet-ef
```

## 1. Drop Database
```
dotnet ef database drop --startup-project OIG.Survey.App/OIG.Survey.App.csproj --project OIG.Survey.Data.Database/OIG.Survey.Data.Database.csproj --context DataDbContext --verbose -- "Host=localhost;Username=postgres;Password=root;Database=oig-survey-app.db;Port=5433"
```

## 2. Add Migration
```
dotnet ef migrations add InitialCreate --startup-project OIG.Survey.App/OIG.Survey.App.csproj --project OIG.Survey.Data.Database/OIG.Survey.Data.Database.csproj --context DataDbContext --verbose -- "Host=localhost;Username=postgres;Password=root;Database=oig-survey-app.db;Port=5433"
```

## 2. Update Database
```
dotnet ef database update --startup-project OIG.Survey.App/OIG.Survey.App.csproj --project OIG.Survey.Data.Database/OIG.Survey.Data.Database.csproj --context DataDbContext --verbose -- "Host=127.0.0.1;Username=postgres;Password=root;Database=oig-survey-app.db;Port=5433"
```
