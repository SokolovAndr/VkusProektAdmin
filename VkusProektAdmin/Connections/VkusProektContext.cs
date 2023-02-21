using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VkusProektAdmin.Connections;

public partial class VkusProektContext : DbContext
{
    public VkusProektContext() => Database.Migrate();

    public VkusProektContext(DbContextOptions<VkusProektContext> options)
        : base(options)
    {
    }

    public DbSet<Bludo> Bludos { get; set; }

    public  DbSet<Category> Categories { get; set; }

    public  DbSet<Order> Orders { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }

    public  DbSet<ShopCartItem> ShopCartItems { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocaldb;Database=VkusProekt;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bludo>(entity =>
        {
            entity.ToTable("Bludo");

            entity.HasIndex(e => e.CategoryId, "IX_Bludo_categoryID");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Available).HasColumnName("available");
            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.Img).HasColumnName("img");
            entity.Property(e => e.IsFavourite).HasColumnName("isFavourite");
            entity.Property(e => e.LongDesc).HasColumnName("longDesc");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ShortDesc).HasColumnName("shortDesc");

            entity.HasOne(d => d.Category).WithMany(p => p.Bludos).HasForeignKey(d => d.CategoryId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName).HasColumnName("categoryName");
            entity.Property(e => e.Desc).HasColumnName("desc");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adress)
                .HasMaxLength(35)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("adress");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("name");
            entity.Property(e => e.OrderTime).HasColumnName("orderTime");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(25)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("surname");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("OrderDetail");

            entity.HasIndex(e => e.BludoId, "IX_OrderDetail_bludoID");

            entity.HasIndex(e => e.OrderId, "IX_OrderDetail_orderID");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BludoId).HasColumnName("bludoID");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Bludo).WithMany(p => p.OrderDetails).HasForeignKey(d => d.BludoId);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails).HasForeignKey(d => d.OrderId);
        });

        modelBuilder.Entity<ShopCartItem>(entity =>
        {
            entity.ToTable("ShopCartItem");

            entity.HasIndex(e => e.Bludoid, "IX_ShopCartItem_bludoid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bludoid).HasColumnName("bludoid");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Bludo).WithMany(p => p.ShopCartItems).HasForeignKey(d => d.Bludoid);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
