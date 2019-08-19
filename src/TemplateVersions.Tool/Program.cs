using System;
using McMaster.Extensions.CommandLineUtils;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TemplateVersions.Tool.Tests")]
namespace TemplateVersions.Tool
{
    [Command(Name = "templateversions", Description = "")]
    [HelpOption]
    class Program
    {

        private readonly IConsole _console;

        public Program(IConsole console)
        {
            _console = console;
        }

        public void InvokeMain(string[] args)
        {
            CommandLineApplication.Execute<Program>(this._console, args);
        }

        public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        [Option(Description = "The dotnet SDK version to check for. IE: v2.2.401")]
        public string sdkversion { get; }

        [Option(Description = "List SDK version in .templateengine directory and exit.")]
        public bool list { get; }

        [Option(Description = "List all templates across all your installed SDKs.")]
        public bool all { get; }

        [Option(Description = "Like --all, except removes SDK versions and orders the ouput.")]
        public bool noversionall { get; }

        private void OnExecute()
        {
            var templatePath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @".templateengine\dotnetcli");
            var coreSdkVersions = Directory.EnumerateDirectories(templatePath).OrderByDescending(x => x.StripFullPathFromDirectory()).ToList();
            var highestSDKVersion = coreSdkVersions.First();
            highestSDKVersion = highestSDKVersion.StripFullPathFromDirectory();

            if (list)
            {
                coreSdkVersions.ForEach(directory => _console.WriteLine(directory.StripFullPathFromDirectory()));
                return;
            }

            if (all || noversionall)
            {
                if(noversionall)
                {                    
                    var results = new List<string>();
                    foreach (var directory in coreSdkVersions)
                    {
                        var directoryNoPath = directory.StripFullPathFromDirectory();
                        var packagesPathForDirectory = Path.Join(templatePath, directoryNoPath, "packages");

                        _console.WriteLine("DEBUG");
                        _console.WriteLine(directoryNoPath);
                        _console.WriteLine(packagesPathForDirectory);

                        var filesForDirectory = new List<string>(Directory.EnumerateFiles(packagesPathForDirectory));

                        _console.WriteLine("DEBUG 2");
                        _console.WriteLine(filesForDirectory);

                        results.AddRange(filesForDirectory.Select(x => x.StripFullPathFromDirectory()));
                    }

                    results.Sort();

                    results.ForEach(file => _console.WriteLine(file));
                }
                else
                {
                    foreach (var directory in coreSdkVersions)
                    {
                        var directoryNoPath = directory.StripFullPathFromDirectory();

                        _console.WriteLine(new string('-', 20));
                        _console.WriteLine(directoryNoPath);
                        _console.WriteLine(new string('-', 20));

                        var packagesPathForDirectory = Path.Join(templatePath, directoryNoPath, "packages");
                        var filesForDirectory = new List<string>(Directory.EnumerateFiles(packagesPathForDirectory));

                        filesForDirectory.ForEach(file => _console.WriteLine(file.StripFullPathFromDirectory()));
                    }
                }

                return;
            }

            var version = !string.IsNullOrEmpty(sdkversion)
                ? sdkversion
                : highestSDKVersion;

            var packagesPath = Path.Join(templatePath, version, "packages");

            if (!Directory.Exists(packagesPath))
            {
                _console.WriteLine($"Could not find a core SDK directory in {templatePath} matching {version}");
                return;
            }

            var files = new List<string>(Directory.EnumerateFiles(packagesPath));

            files.ForEach(file => _console.WriteLine(file.StripFullPathFromDirectory()));
            return;            
        }

    }
}
