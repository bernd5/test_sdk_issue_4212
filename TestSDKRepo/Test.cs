using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace TestSDKRepo
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var msBuildInstance = MSBuildLocator.RegisterDefaults();
            
            using var workspace = MSBuildWorkspace.Create();
            var project = await workspace.OpenProjectAsync("D:\\work\\TestSDKRepo\\TestSDKRepo\\TestSDKRepo.csproj");

            var failures = workspace.Diagnostics.Where(d => d.Kind == WorkspaceDiagnosticKind.Failure);
            if (failures.Any())
            {
                throw new Exception(string.Join(Environment.NewLine, failures.Select(f => f.Message)));
            }
        }
    }
}