using BenchmarkDotNet.Attributes;

namespace ConsoleBenchmarks
{
	[MemoryDiagnoser]
    public class ArrayDiffCl
    {
        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public int[] ArrayDiff(int[] a, int[] b)
        {
            var u2 = b.ToHashSet();
            var res = new List<int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (!u2.Contains(a[i]))
                {
                    res.Add(a[i]);
                }
            }
            return res.ToArray();
        }
        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public int[] ArrayDiff2(int[] a, int[] b)
        {
            return a.Where(n => !b.Contains(n)).ToArray();
        }
        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public int[] ArrayDiff3(int[] a, int[] b)
        {

            HashSet<int> bSet = new HashSet<int>(b);

            return a.Where(v => !bSet.Contains(v)).ToArray();
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public int[] ArrayDiff4(int[] a, int[] b) => Array.FindAll(a, m => !b.Contains(m));

        public IEnumerable<object[]> Data()
        {
            yield return new object[] { new int[] { 1, 2, 2, 3, 4, 5, 5, 6 }, new int[] { 1, 2 } };
        }
    }
}
