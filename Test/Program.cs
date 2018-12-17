
using System;
using System.Reflection;
using System.Runtime.Loader;

namespace TestLoadContext
{
    // Repro for https://github.com/dotnet/coreclr/issues/20607

    class Program
    {
        class MyAssemblyLoadContext : AssemblyLoadContext
        {
            protected override Assembly Load(AssemblyName assemblyName) => null;
        }

        static void Main(string[] args)
        {
            Run("Hello from main context");

            var loadContext = new MyAssemblyLoadContext();
            var assembly = loadContext.LoadFromAssemblyPath(typeof(Program).Assembly.Location);
            var runMethod = assembly
                .GetType(typeof(Program).FullName)
                .GetTypeInfo()
                .GetMethod("Run");

            runMethod.Invoke(null, new object[] { "Hello from custom context!" });
        }

        public static void Run(string message) => Console.WriteLine(message);
    }
}
