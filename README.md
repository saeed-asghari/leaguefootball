[![Build status](https://ci.appveyor.com/api/projects/status/uafekpggogduuh9c/branch/master?svg=true)](https://ci.appveyor.com/project/saeed-asghari/leaguefootball/branch/master)
## The Project
Football League Manager
## Technologies
* [.NET Core 5.0]
## JWT powered by [aspnet-core-3-jwt-refresh-tokens-api](https://github.com/cornflourblue/aspnet-core-3-jwt-refresh-tokens-api) 
## Config appveyor.yml and BuildScript powered by [Suzianna](https://github.com/suzianna/Suzianna)
### Installing
Follow these steps to get your development environment set up:
1. Clone the repository
2. At the root directory, restore required packages by running:
```csharp
dotnet restore
```
3. Next, build the solution by running:
```csharp
dotnet build
```
4. Next, update db:
```csharp
dotnet ef database update
```
4. Next, running:
```csharp
dotnet run

```
