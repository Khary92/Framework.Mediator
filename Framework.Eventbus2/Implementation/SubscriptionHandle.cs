namespace Framework.Eventbus.Implementation;

public class SubscriptionHandle : IDisposable
{
    private readonly Action _unsubscribeAction;
    public Delegate Handler { get; }
    public Guid Id { get; } = Guid.NewGuid();

    public SubscriptionHandle(Action unsubscribeAction, Delegate handler)
    {
        _unsubscribeAction = unsubscribeAction;
        Handler = handler;
    }

    public void Dispose() => _unsubscribeAction.Invoke();
}
