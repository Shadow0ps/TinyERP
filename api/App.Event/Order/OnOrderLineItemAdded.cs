namespace App.Event.Order
{
    using App.Common.Event;
    using System;

    public class OnOrderLineItemAdded : BaseEvent
    {
        public Guid OrderId { get; set; }
        public decimal Price { get; set; }
        public OnOrderLineItemAdded(Guid orderId, decimal price) : base()
        {
            this.OrderId = orderId;
            this.Price = price;
        }
    }
}
