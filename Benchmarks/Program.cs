using BenchmarkDotNet.Running;

namespace Benchmarks
{
    public class Program
    {
        /// <summary>
        /// usage:
        /// dotnet run -c Release -f $moniker --filter * --runtimes net472 netcoreapp31 net5.0-windows
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}
