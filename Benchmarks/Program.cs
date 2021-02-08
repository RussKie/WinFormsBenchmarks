using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.CsProj;
using BenchmarkDotNet.Toolchains.DotNetCli;

namespace Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = DefaultConfig.Instance
                //.With(Job.Default.With(CsProjClassicNetToolchain.Net472))
                .With(Job.Default.With(CsProjCoreToolchain.NetCoreApp31))
                .With(Job.Default.With(CsProjCoreToolchain.From(new NetCoreAppSettings("net5.0-windows", null, ".NET 5.0"))))
                ;

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
        }
    }
}
