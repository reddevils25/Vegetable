using System;
using System.Collections.Generic;

namespace Vegetable.Models;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public int? Price { get; set; }

    public int StockQuantity { get; set; }

    public string CategoryId { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? CategoryProductId { get; set; }

    public bool? IsNew { get; set; }

    public int? PriceSale { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
