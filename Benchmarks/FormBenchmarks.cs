using BenchmarkDotNet.Attributes;
using System.Windows.Forms;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class FormBenchmarks
    {
        [Benchmark]
        public bool CreateAndShowForm()
        {
            using (var form = new Form())
            {
                form.Show();
                form.Close();
            }
            return true;
        }
    }
}