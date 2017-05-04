namespace App.Api.Features.Order
{
    using Command.Order;
    using App.Common.Command;
    using App.Common.MVC.Attributes;
    using System.Web.Http;
    using Aggregate.Order;
    using System;

    [RoutePrefix("api/orders")]
    public class OrdersController : CommandHandlerController<OrderAggregate>
    {
        [Route("")]
        [HttpPost()]
        [ResponseWrapper()]
        public void CreateOrder(CreateOrderRequest request)
        {
            this.Execute(request);
        }

        [Route("{orderId}/orderLines")]
        [HttpPost()]
        [ResponseWrapper()]
        public void AddOrderLine(Guid orderId, AddOrderLineRequest request)
        {
            request.OrderId = orderId;
            this.Execute(request);
        }
    }
}
