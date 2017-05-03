namespace App.Query.Order
{
    using System;
    public interface IOrderQuery
    {
        void CreateOrder(Guid orderId);
    }
}
