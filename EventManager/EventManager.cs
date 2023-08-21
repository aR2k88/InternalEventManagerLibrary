using InternalEventManagerLibrary.Interfaces;

namespace InternalEventManagerLibrary.EventManager;

public class EventManager : IEventManager
{
    private readonly Dictionary<Type, List<object>> _eventHandlers = new Dictionary<Type, List<object>>();
    
    public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
    {
        if (_eventHandlers.TryGetValue(typeof(TEvent), out var handlers))
        {
            foreach (var handler in handlers.OfType<IEventConsumer<TEvent>>())
            {
                handler.Consume(@event);
            }
        }
    }

    public void Subscribe<TEvent>(IEventConsumer<TEvent> handler) where TEvent : IEvent
    {
        if (_eventHandlers.TryGetValue(typeof(TEvent), out var handlers))
        {
            handlers.Add(handler);
        }
        else
        {
            _eventHandlers[typeof(TEvent)] = new List<object> { handler };
        }
    }

    public void Unsubscribe<TEvent>(IEventConsumer<TEvent> handler) where TEvent : IEvent
    {
        if (_eventHandlers.TryGetValue(typeof(TEvent), out var handlers))
        {
            handlers.Remove(handler);
        }
    }
}