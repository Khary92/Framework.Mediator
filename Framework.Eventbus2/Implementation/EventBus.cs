using System.Collections.Concurrent;
using Framework.Eventbus.Contract;

namespace Framework.Eventbus.Implementation;

public class EventBus : IEventSubscriber, IEventPublisher
{
    private readonly ConcurrentDictionary<Type, List<SubscriptionHandle>> _subscribers = new();
    
    public IDisposable Subscribe<TEvent>(Func<TEvent, Task> handler)
    {
        var list = _subscribers.GetOrAdd(typeof(TEvent), _ => new List<SubscriptionHandle>());

        SubscriptionHandle? handle = null;
        Action unsubscribe = () =>
        {
            lock (list)
            {
                list.Remove(handle!);
            }
        };

        handle = new SubscriptionHandle(unsubscribe, handler);

        lock (list)
        {
            list.Add(handle);
        }

        return handle;
    }

    public async Task PublishAsync<TEvent>(TEvent eventData)
    {
        var eventType = typeof(TEvent);

        if (!_subscribers.TryGetValue(eventType, out var list))
            return;

        List<SubscriptionHandle> snapshot;

        lock (list)
        {
            snapshot = list.ToList();
        }

        foreach (var handle in snapshot)
        {
            if (handle.Handler is not Func<TEvent, Task> func) continue;
            
            try
            {
                await func(eventData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Subscriber: {ex.Message}");
            }
        }
    }
}