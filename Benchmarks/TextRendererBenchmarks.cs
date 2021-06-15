using BenchmarkDotNet.Attributes;
using System.Drawing;
using System.Windows.Forms;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class TextRendererBenchmarks
    {
        private Control _control;
        private Font _font;

        // Executed only once per a benchmarked method after initialization of benchmark parameters and before all
        // the benchmark method invocations.
        [GlobalSetup]
        public void GlobalSetup()
        {
            _control = new();
            _font = new Font("Arial", 9f);
        }

        // Executed only once per a benchmarked method after all the benchmark method invocations. 
        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _control.Dispose();
            _font.Dispose();
        }

        [Benchmark]
        [Arguments(10)]
        [Arguments(10000)]
        public void MeasureText_ControlFont(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                TextRenderer.MeasureText("Test String", _control.Font);
            }
        }

        [Benchmark]
        [Arguments(10)]
        [Arguments(10000)]
        public void MeasureText_DefaultFont(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                TextRenderer.MeasureText("Test String", SystemFonts.DefaultFont);
            }
        }

        [Benchmark]
        [Arguments(10)]
        [Arguments(10000)]
        public void MeasureText_LocalFont(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                TextRenderer.MeasureText("Test String", _font);
            }
        }
    }
}
