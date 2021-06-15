using BenchmarkDotNet.Attributes;
using System.Drawing;
using System.Windows.Forms;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class FontBenchmarks
    {
        [Benchmark]
        public Font CreateFont()
        {
            return new Font("Arial", 9f);
        }

        [Benchmark]
        public Font SystemDefaultFont()
        {
            return SystemFonts.DefaultFont;
        }
    }
}
