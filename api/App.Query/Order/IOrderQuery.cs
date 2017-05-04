namespace App.Query.Order
{
    using System;
    public interface IOrderQuery
    {
        void CreateOrder(Guid orderId);
        void AddOrderLineItem(Guid orderId, decimal price);
        void UpdateCustomerDetail(Guid orderId, string customerName);
    }
}
