using BenchmarkDotNet.Attributes;

[MemoryDiagnoser(false)]
public class LoopBenchmarks
{
    private int[] _data;

    [GlobalSetup]
    public void Setup()
    {
        _data = new int[10000];
    }

    [Benchmark]
    public int CountNormalLoop()
    {
        int result = 0;
        for (int i = 0; i < _data.Length; i++)
        {
            result += _data[i];
        }
        return result;
    }

    [Benchmark]
    public int CountUnwoundLoop()
    {
        //int result = 0;
        //foreach (int value in _data)
        //{
        //    result += value;
        //}
        //return result;

        int result = 0;
        int count = _data.Length;
        for (int i = 0; i < count; i++)
        {
            result += _data[i];
        }
        return result;
    }
}