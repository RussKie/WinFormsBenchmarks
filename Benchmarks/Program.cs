using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.CsProj;

namespace Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = DefaultConfig.Instance
                //.With(Job.Default.With(CsProjClassicNetToolchain.Net472))
                .With(Job.Default.With(CsProjCoreToolchain.NetCoreApp50))
                //.With(Job.Default.With(CsProjCoreToolchain.From(new NetCoreAppSettings("netcoreapp5.0", null, ".NET Core 5.0"))))
                ;

            var summary = BenchmarkSwitcher.FromTypes(new[] { typeof(FormControlsBenchmarks) }).RunAll(config: config);
        }
    }
}
