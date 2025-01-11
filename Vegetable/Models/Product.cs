using System;
using System.Collections.Generic;

namespace Vegetable.Models;

public partial class Product
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public string? Description { get; set; }
    public int? Price { get; set; }
    public int? StockQuantity { get; set; }
    public int? CategoryId { get; set; }
    public string? ImageUrl { get; set; }
    public int? PriceSale { get; set; }
    public int? Weight { get; set; }
    public string? Alias { get; set; }
    public int? Star { get; set; }
    public bool IsActive { get; set; }
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
    public virtual Category? Category { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
}
