using System;
using System.Collections.Generic;

namespace VkusProektAdmin;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int BludoId { get; set; }

    public long Price { get; set; }

    public virtual Bludo Bludo { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
