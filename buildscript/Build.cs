using Nuke.Common;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using System;
using System.Linq;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.RunUnitTest);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution] readonly Solution Solution;

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            GlobDirectories(Solution.Directory, "test/**/obj", "test/**/bin").ForEach(DeleteDirectory);
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetRestore(x => x.SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(x => x.SetProjectFile(Solution).EnableNoRestore());
        });

    Target RunUnitTest => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            var testProjects = Solution.AllProjects
            .Where(x => x.Name.Contains("Test.Unit", StringComparison.OrdinalIgnoreCase))
            .ToList();

            Console.WriteLine($"{testProjects.Count} test counter");

            foreach (var test in testProjects)
                DotNetTest(x => x.SetProjectFile(Solution)
                .EnableNoBuild()
                .EnableNoRestore());
        });
}
