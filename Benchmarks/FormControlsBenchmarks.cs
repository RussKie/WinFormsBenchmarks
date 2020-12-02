using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class FormControlsBenchmarks
    {
        private Form _form;

        [Params(10, 100, 1000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            _form = new Form();

            foreach (int i in Enumerable.Range(1, N))
            {
                var label = new Label { Name = $"label{i:####0}" };
                var textBox = new TextBox { Name = $"textBox{i:####0}" };
                var button = new Button { Name = $"button{i:####0}" };

                _form.Controls.Add(label);
                _form.Controls.Add(textBox);
                _form.Controls.Add(button);
            }
        }

        [GlobalCleanup]
        public void Dispose()
        {
            _form.Dispose();
        }

        [Benchmark(Baseline = true)]
        public string EnumerateControls_GetEnumerator_var()
        {
            string name = null;
            foreach (var c in _form.Controls)
            {
                name = ((Control)c).Name;
            }

            return name;
        }

        [Benchmark]
        public string EnumerateControls_GetEnumerator_explicit()
        {
            string name = null;
            foreach (Control c in _form.Controls)
            {
                name = c.Name;
            }

            return name;
        }
    }
}
