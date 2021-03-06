#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
#addin "Cake.Powershell"
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("../");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
    {
        CleanDirectory(@"C:\inetpub\wwwroot\Links");
    });

Task("Build")
    .IsDependentOn("Clean")
    .ContinueOnError()
    .Does(() =>
{
    StartPowershellScript("npm run build_automation", args =>
        {
        });
});

Task("CopyFiles")
    .Does(() =>
    {
        CopyDirectory(@"../dist/Links/", @"C:\inetpub\wwwroot\Links");
    });



//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Build")
    .ContinueOnError()

    .IsDependentOn("CopyFiles");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
