using System;
using System.IO;
using McMaster.NETCore.Plugins;

namespace Loader
{
    class Program
    {
        static void Main(string[] args)
        {
            var appDirectory = Path.Combine(
                Path.GetDirectoryName(typeof(Program).Assembly.Location),
                "..",
                "..",
                "..",
                "..",
                "App",
                "bin",
                "Debug",
                "netcoreapp2.2");
            var appAssemblyPath = Path.Combine(appDirectory, "App.dll");
            
            var loader = PluginLoader.CreateFromAssemblyFile(appAssemblyPath);
            var appAssembly = loader.LoadDefaultAssembly();

            appAssembly.EntryPoint.Invoke(null, new object[] { Array.Empty<string>() });
        }
    }
}
