using System.Collections.Concurrent;

namespace Framework.Eventbus.Contract;

public interface IEventSubscriber
{
    IDisposable Subscribe<TEvent>(Func<TEvent, Task> handler);
}