using System;
using System.Collections.Generic;

namespace VkusProektAdmin;

public partial class ShopCartItem
{
    public int Id { get; set; }

    public int? Bludoid { get; set; }

    public int Price { get; set; }

    public string? ShopCartId { get; set; }

    public virtual Bludo? Bludo { get; set; }
}
