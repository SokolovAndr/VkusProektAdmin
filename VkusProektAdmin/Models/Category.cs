using System;
using System.Collections.Generic;

namespace VkusProektAdmin;

public partial class Category
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public string? Desc { get; set; }

    public virtual ICollection<Bludo> Bludos { get; } = new List<Bludo>();
}
