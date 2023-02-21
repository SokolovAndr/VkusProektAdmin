using System;
using System.Collections.Generic;

namespace VkusProektAdmin;

public partial class Bludo
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ShortDesc { get; set; }

    public string? LongDesc { get; set; }

    public string? Img { get; set; }

    public int Price { get; set; }

    public bool IsFavourite { get; set; }

    public bool Available { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual ICollection<ShopCartItem> ShopCartItems { get; } = new List<ShopCartItem>();
}
