namespace Mythlog.Tick;

public class TickService
{
    private readonly List<TickListener> _listeners = new();

    public void OnTick(TickListener listener)
    {
        _listeners.Add(listener);
    }

    public void Tick(float delta = 1f)
    {
        foreach (var listener in _listeners)
        {
            listener(delta);
        }
    }
}