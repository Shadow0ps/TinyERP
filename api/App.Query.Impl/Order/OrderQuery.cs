using System;
using App.Common.Data;
using App.Common.Data.MongoDB;
using App.Query.Order;

namespace App.Query.Impl.Order
{
    public class OrderQuery: BaseQueryRepository<App.Query.Entity.Order.Order>, IOrderQuery
    {
        public OrderQuery():base(new MongoDbContext()){}
        public void CreateOrder(Guid orderId)
        {
            this.DbSet.Add(new App.Query.Entity.Order.Order(orderId));
        }
    }
}
