namespace App.Query.Entity.Order
{
    using App.Common.Data;
    using MongoDB.Bson;
    using MongoDB.Kennedy;
    using System;

    public class Order : BaseEntity, IMongoEntity
    {
        public string _accessId
        {
            get { return this.Id.ToString(); }
            set { this.Id = new Guid(value); }
        }
        public ObjectId _id { get; }
        public Guid OrderId { get; set; }
        public string Name { get; set; }
        public Order(Guid orderId)
        {
            this.OrderId = orderId;
        }
    }
}
