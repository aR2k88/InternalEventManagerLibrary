using System.Threading.Tasks;

namespace InternalEventManagerLibrary.Interfaces;

public interface IEventConsumer<TEvent> where TEvent : IEvent
{
    Task Consume(TEvent @event);
}