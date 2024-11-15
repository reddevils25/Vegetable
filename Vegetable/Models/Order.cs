using System;
using System.Collections.Generic;

namespace Vegetable.Models;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public string? UserId { get; set; }

    public string? DiscountId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Status { get; set; }

    public decimal AmountBeforeDiscount { get; set; }

    public decimal TotalAmount { get; set; }

    public string? ShippingAddress { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual User? User { get; set; }
}
