namespace App.Common.Event
{
    using App.Common.Tasks;

    public interface IEventHandler<TEventType> : IBaseTask<TEventType> where TEventType : IEvent
    {
    }
}