namespace App.Event.Order
{
    using App.Common.Event;
    using Common;
    using System;
    public class OnOrderCreated : BaseEvent
    {
        public override Type HandlerType
        {
            get
            {
                return typeof(IEventHandler<OnCustomerDetailChanged>);
            }
        }
        public Guid OrderId { get; set; }
        public OnOrderCreated(Guid orderId):base(EventPriority.High)
        {
            this.OrderId = orderId;
        }
    }
}
