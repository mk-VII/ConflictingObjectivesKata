using System.Diagnostics;

namespace Kata08.helper;

public class MethodTimer<T>
{
    private readonly Stopwatch _stopwatch;
    private readonly Func<Task<T>> _methodToTime;

    public MethodTimer(Func<Task<T>> method)
    {
        _stopwatch = Stopwatch.StartNew();
        _methodToTime = method;
    }

    public async Task<(int elapsedSeconds, T methodResult)> CallTimedMethod()
    {
        _stopwatch.Restart();
        var methodResult = await _methodToTime.Invoke();
        _stopwatch.Stop();

        return (
            (int)_stopwatch.Elapsed.TotalSeconds,
            methodResult);
    }
}