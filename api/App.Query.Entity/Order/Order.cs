namespace App.Query.Entity.Order
{
    using Common.Data.MongoDB;
    using System;
    using System.Collections.Generic;
    using ValueObject.Order;

    public class Order : BaseMongoDbEntity
    {
        public Guid OrderId { get; set; }
        public string Name { get; set; }
        public IList<OrderLine> OrderLines { get; set; }
        public OrderCustomerDetail Customer { get; set; }

        public Order()
        {
            this.OrderLines = new List<OrderLine>();
        }
        public Order(Guid orderId) : this()
        {
            this.OrderId = orderId;
        }
    }
}
