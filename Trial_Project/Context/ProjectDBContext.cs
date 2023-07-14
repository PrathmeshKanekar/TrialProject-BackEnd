using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Trial_Project.Models;

namespace Trial_Project.Context;

public partial class ProjectDBContext : DbContext
{
    public ProjectDBContext()
    {
    }

    public ProjectDBContext(DbContextOptions<ProjectDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Saledetail> Saledetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Prathmesh\\SQLEXPRESS;Initial Catalog=TrialProject;Integrated Security=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasOne(d => d.Client).WithMany(p => p.Sales).HasConstraintName("FK_sales_clients");
        });

        modelBuilder.Entity<Saledetail>(entity =>
        {
            entity.HasOne(d => d.Product).WithMany(p => p.Saledetails).HasConstraintName("FK_saledetails_products");

            entity.HasOne(d => d.Sale).WithMany(p => p.Saledetails).HasConstraintName("FK_saledetails_sales");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
