namespace App.Query.Order
{
    using App.Common.Data;
    using App.Common.Mapping;
    using System;
    public class OrderSummaryItem: BaseEntity, IMappedFrom<App.Query.Entity.Order.Order>
    {
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; }
        public int TotalItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
