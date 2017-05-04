namespace App.Command.Order
{
    using App.Common.Command;
    using System;

    public class AddOrderLineRequest : BaseCommand
    {
        public Guid OrderId { get; set; }
        public decimal Price { get; set; }
    }
}
