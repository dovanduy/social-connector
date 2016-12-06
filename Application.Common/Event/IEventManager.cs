namespace App.Common.Event
{
    public interface IEventManager
    {
        void Pubish<TEventType>(TEventType eventType) where TEventType : IEvent;
    }
}