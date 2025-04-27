
namespace VideoTranscoder2.Utils;

internal class AtomicBoolean
{
    private int _flag = 0;

    public static implicit operator bool(AtomicBoolean obj)
    {
        return Interlocked.CompareExchange(ref obj._flag, 0, 0) == 1;
    }

    public AtomicBoolean Set(bool value)
    {
        if (value)
        {
            Interlocked.CompareExchange(ref _flag, 1, 0);
        }
        else
        {
            Interlocked.CompareExchange(ref _flag, 0, 1);
        }
        return this;
    }
}
