#tool "nuget:?package=xunit.runner.console&version=2.4.1"
#tool "nuget:?package=GitVersion.CommandLine&version=4.0.0"


var solutionPath = Argument("SolutionPath", "../leaguefootball/leaguefootball.sln");
var projects = GetFiles("../leaguefootball/src/**/*.csproj");

Task("Clean")
    .Does(()=>{
      foreach(var project in projects) {
          DotNetCoreClean(project.FullPath);
      }
});

Task("Restore-NuGet-Packages")
    .Does(() =>
{
    var settings = new DotNetCoreRestoreSettings
    {
         PackagesDirectory = "../packages",
         DisableParallel = true,
    };
    foreach(var project in projects) {
        DotNetCoreRestore(project.FullPath, settings);
    }
});



Task("Build")
    .Does(()=>
    {
        foreach(var project in projects) {
            DotNetCoreBuild(project.FullPath);
        }
    });


Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore-NuGet-Packages")
    .IsDependentOn("Build");

RunTarget("Default");
