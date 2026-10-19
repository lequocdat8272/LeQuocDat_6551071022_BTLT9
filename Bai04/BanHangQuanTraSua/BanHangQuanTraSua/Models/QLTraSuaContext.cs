using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BanHangQuanTraSua.Models;

public partial class QLTraSuaContext : DbContext
{
    public QLTraSuaContext()
    {
    }

    public QLTraSuaContext(DbContextOptions<QLTraSuaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<DanhMucMon> DanhMucMons { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<MonUong> MonUongs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Configurations.ConfigurationHelper.GetConnectionString());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.MaMon });

            entity.ToTable("ChiTietHoaDon");

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaHd)
                .HasConstraintName("FK_ChiTietHoaDon_HoaDon");

            entity.HasOne(d => d.MaMonNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaMon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHoaDon_MonUong");
        });

        modelBuilder.Entity<DanhMucMon>(entity =>
        {
            entity.HasKey(e => e.MaDm).HasName("PK__DanhMucM__2725866E22199ACD");

            entity.ToTable("DanhMucMon");

            entity.Property(e => e.MaDm).HasColumnName("MaDM");
            entity.Property(e => e.TenDm)
                .HasMaxLength(50)
                .HasColumnName("TenDM");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__HoaDon__2725A6E0AC265761");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.HinhThucTt)
                .HasMaxLength(20)
                .HasColumnName("HinhThucTT");
            entity.Property(e => e.NgayLap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<MonUong>(entity =>
        {
            entity.HasKey(e => e.MaMon).HasName("PK__MonUong__3A5B29A819192809");

            entity.ToTable("MonUong");

            entity.Property(e => e.DangBan).HasDefaultValue(true);
            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.MaDm).HasColumnName("MaDM");
            entity.Property(e => e.TenMon).HasMaxLength(100);

            entity.HasOne(d => d.MaDmNavigation).WithMany(p => p.MonUongs)
                .HasForeignKey(d => d.MaDm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MonUong_DanhMucMon");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
