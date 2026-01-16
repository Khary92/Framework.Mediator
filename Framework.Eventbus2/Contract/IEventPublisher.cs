namespace Framework.Eventbus.Contract;

public interface IEventPublisher
{
    Task PublishAsync<TEvent>(TEvent eventData);
}