namespace App.Common.Event
{
    using System;
    public class BaseEvent : IEvent
    {
        public virtual Type HandlerType { get; }
        public EventPriority Priority { get; set; }
        public BaseEvent(EventPriority priority = EventPriority.Normal)
        {
            this.Priority = priority;
        }
    }
}
