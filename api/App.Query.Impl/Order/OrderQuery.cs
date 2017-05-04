namespace App.Query.Impl.Order
{
    using System;
    using App.Common.Data;
    using App.Common.Data.MongoDB;
    using App.Query.Order;
    using App.Query.Entity.Order;
    using System.Linq;

    public class OrderQuery: BaseQueryRepository<Order>, IOrderQuery
    {
        public OrderQuery():base(new MongoDbContext()){}

        public void AddOrderLineItem(Guid orderId, decimal price)
        {
            App.Query.Entity.Order.Order order = this.DbSet.AsQueryable().FirstOrDefault(item => item.OrderId == orderId);
            this.DbSet.Delete(order._id.ToString());
            order.OrderLines.Add(new OrderLine(orderId, price));
            this.DbSet.Add(order);
        }
        public void CreateOrder(Guid orderId)
        {
             this.DbSet.Add(new App.Query.Entity.Order.Order(orderId));
        }
    }
}
