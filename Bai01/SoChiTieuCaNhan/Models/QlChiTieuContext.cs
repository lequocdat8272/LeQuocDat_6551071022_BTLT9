using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SoChiTieuCaNhan.Config;

namespace SoChiTieuCaNhan.Models;

public partial class QlChiTieuContext : DbContext
{
    private readonly string? _connectionString;

    public QlChiTieuContext()
    {
    }

    public QlChiTieuContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public QlChiTieuContext(DbContextOptions<QlChiTieuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTieu> ChiTieus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string conn = !string.IsNullOrEmpty(_connectionString)
                ? _connectionString
                : AppConfigService.Instance.ConnectionStrings.DefaultConnection;

            if (string.IsNullOrWhiteSpace(conn))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' không được tìm thấy trong file cấu hình appsettings.json.");
            }

            optionsBuilder.UseSqlServer(conn);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTieu>(entity =>
        {
            entity.HasKey(e => e.MaCt).HasName("PK__ChiTieu__27258E74077EB054");

            entity.ToTable("ChiTieu");

            entity.Property(e => e.MaCt).HasColumnName("MaCT");
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.LoaiChi).HasMaxLength(30);
            entity.Property(e => e.NoiDung).HasMaxLength(100);
            entity.Property(e => e.SoTien).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
