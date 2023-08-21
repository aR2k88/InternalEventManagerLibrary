namespace InternalEventManagerLibrary.Interfaces;

public interface IEventManager
{
    void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    void Subscribe<TEvent>(IEventConsumer<TEvent> handler) where TEvent : IEvent;
    void Unsubscribe<TEvent>(IEventConsumer<TEvent> handler) where TEvent : IEvent;
}