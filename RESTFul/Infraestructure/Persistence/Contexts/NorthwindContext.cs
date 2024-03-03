﻿using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Contexts;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlphabeticalListOfProducts> AlphabeticalListOfProducts { get; set; }

    public virtual DbSet<Categories> Categories { get; set; }

    public virtual DbSet<CategorySalesFor1997> CategorySalesFor1997 { get; set; }

    public virtual DbSet<CurrentProductList> CurrentProductList { get; set; }

    public virtual DbSet<CustomerAndSuppliersByCity> CustomerAndSuppliersByCity { get; set; }

    public virtual DbSet<CustomerDemographics> CustomerDemographics { get; set; }

    public virtual DbSet<Customers> Customers { get; set; }

    public virtual DbSet<Employees> Employees { get; set; }

    public virtual DbSet<Invoices> Invoices { get; set; }

    public virtual DbSet<OrderDetails> OrderDetails { get; set; }

    public virtual DbSet<OrderDetailsExtended> OrderDetailsExtended { get; set; }

    public virtual DbSet<OrderSubtotals> OrderSubtotals { get; set; }

    public virtual DbSet<Orders> Orders { get; set; }

    public virtual DbSet<OrdersQry> OrdersQry { get; set; }

    public virtual DbSet<ProductSalesFor1997> ProductSalesFor1997 { get; set; }

    public virtual DbSet<Products> Products { get; set; }

    public virtual DbSet<ProductsAboveAveragePrice> ProductsAboveAveragePrice { get; set; }

    public virtual DbSet<ProductsByCategory> ProductsByCategory { get; set; }

    public virtual DbSet<QuarterlyOrders> QuarterlyOrders { get; set; }

    public virtual DbSet<Region> Region { get; set; }

    public virtual DbSet<SalesByCategory> SalesByCategory { get; set; }

    public virtual DbSet<SalesTotalsByAmount> SalesTotalsByAmount { get; set; }

    public virtual DbSet<Shippers> Shippers { get; set; }

    public virtual DbSet<SummaryOfSalesByQuarter> SummaryOfSalesByQuarter { get; set; }

    public virtual DbSet<SummaryOfSalesByYear> SummaryOfSalesByYear { get; set; }

    public virtual DbSet<Suppliers> Suppliers { get; set; }

    public virtual DbSet<Territories> Territories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlphabeticalListOfProducts>(entity =>
        {
            entity.ToView("Alphabetical list of products");
        });

        modelBuilder.Entity<CategorySalesFor1997>(entity =>
        {
            entity.ToView("Category Sales for 1997");
        });

        modelBuilder.Entity<CurrentProductList>(entity =>
        {
            entity.ToView("Current Product List");

            entity.Property(e => e.ProductId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<CustomerAndSuppliersByCity>(entity =>
        {
            entity.ToView("Customer and Suppliers by City");
        });

        modelBuilder.Entity<CustomerDemographics>(entity =>
        {
            entity.HasKey(e => e.CustomerTypeId).IsClustered(false);

            entity.Property(e => e.CustomerTypeId).IsFixedLength();
        });

        modelBuilder.Entity<Customers>(entity =>
        {
            entity.Property(e => e.CustomerId).IsFixedLength();

            entity.HasMany(d => d.CustomerType).WithMany(p => p.Customer)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerCustomerDemo",
                    r => r.HasOne<CustomerDemographics>().WithMany()
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomerCustomerDemo"),
                    l => l.HasOne<Customers>().WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomerCustomerDemo_Customers"),
                    j =>
                    {
                        j.HasKey("CustomerId", "CustomerTypeId").IsClustered(false);
                        j.IndexerProperty<string>("CustomerId")
                            .HasMaxLength(5)
                            .IsFixedLength()
                            .HasColumnName("CustomerID");
                        j.IndexerProperty<string>("CustomerTypeId")
                            .HasMaxLength(10)
                            .IsFixedLength()
                            .HasColumnName("CustomerTypeID");
                    });
        });

        modelBuilder.Entity<Employees>(entity =>
        {
            entity.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation).HasConstraintName("FK_Employees_Employees");

            entity.HasMany(d => d.Territory).WithMany(p => p.Employee)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeTerritories",
                    r => r.HasOne<Territories>().WithMany()
                        .HasForeignKey("TerritoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeeTerritories_Territories"),
                    l => l.HasOne<Employees>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeeTerritories_Employees"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "TerritoryId").IsClustered(false);
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("EmployeeID");
                        j.IndexerProperty<string>("TerritoryId")
                            .HasMaxLength(20)
                            .HasColumnName("TerritoryID");
                    });
        });

        modelBuilder.Entity<Invoices>(entity =>
        {
            entity.ToView("Invoices");

            entity.Property(e => e.CustomerId).IsFixedLength();
        });

        modelBuilder.Entity<OrderDetails>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK_Order_Details");

            entity.Property(e => e.Quantity).HasDefaultValue((short)1);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Details_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Details_Products");
        });

        modelBuilder.Entity<OrderDetailsExtended>(entity =>
        {
            entity.ToView("Order Details Extended");
        });

        modelBuilder.Entity<OrderSubtotals>(entity =>
        {
            entity.ToView("Order Subtotals");
        });

        modelBuilder.Entity<Orders>(entity =>
        {
            entity.Property(e => e.CustomerId).IsFixedLength();
            entity.Property(e => e.Freight).HasDefaultValue(0m);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders).HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders).HasConstraintName("FK_Orders_Employees");

            entity.HasOne(d => d.ShipViaNavigation).WithMany(p => p.Orders).HasConstraintName("FK_Orders_Shippers");
        });

        modelBuilder.Entity<OrdersQry>(entity =>
        {
            entity.ToView("Orders Qry");

            entity.Property(e => e.CustomerId).IsFixedLength();
        });

        modelBuilder.Entity<ProductSalesFor1997>(entity =>
        {
            entity.ToView("Product Sales for 1997");
        });

        modelBuilder.Entity<Products>(entity =>
        {
            entity.Property(e => e.ReorderLevel).HasDefaultValue((short)0);
            entity.Property(e => e.UnitPrice).HasDefaultValue(0m);
            entity.Property(e => e.UnitsInStock).HasDefaultValue((short)0);
            entity.Property(e => e.UnitsOnOrder).HasDefaultValue((short)0);

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products).HasConstraintName("FK_Products_Suppliers");
        });

        modelBuilder.Entity<ProductsAboveAveragePrice>(entity =>
        {
            entity.ToView("Products Above Average Price");
        });

        modelBuilder.Entity<ProductsByCategory>(entity =>
        {
            entity.ToView("Products by Category");
        });

        modelBuilder.Entity<QuarterlyOrders>(entity =>
        {
            entity.ToView("Quarterly Orders");

            entity.Property(e => e.CustomerId).IsFixedLength();
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).IsClustered(false);

            entity.Property(e => e.RegionId).ValueGeneratedNever();
            entity.Property(e => e.RegionDescription).IsFixedLength();
        });

        modelBuilder.Entity<SalesByCategory>(entity =>
        {
            entity.ToView("Sales by Category");
        });

        modelBuilder.Entity<SalesTotalsByAmount>(entity =>
        {
            entity.ToView("Sales Totals by Amount");
        });

        modelBuilder.Entity<SummaryOfSalesByQuarter>(entity =>
        {
            entity.ToView("Summary of Sales by Quarter");
        });

        modelBuilder.Entity<SummaryOfSalesByYear>(entity =>
        {
            entity.ToView("Summary of Sales by Year");
        });

        modelBuilder.Entity<Territories>(entity =>
        {
            entity.HasKey(e => e.TerritoryId).IsClustered(false);

            entity.Property(e => e.TerritoryDescription).IsFixedLength();

            entity.HasOne(d => d.Region).WithMany(p => p.Territories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Territories_Region");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
