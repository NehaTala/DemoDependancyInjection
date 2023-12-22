using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DPI.Data.Models;

public partial class TestCoreContext : DbContext
{
    public TestCoreContext()
    {
    }

    public TestCoreContext(DbContextOptions<TestCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LPT180\\SQL2019; Database=TestCore; User ID=sa; Password=Tatva@123; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.PkRoleId).HasName("PK__tbl_Role__B09F5C297088AD8F");

            entity.ToTable("tbl_Roles");

            entity.Property(e => e.PkRoleId).HasColumnName("PK_RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.PkUserId).HasName("PK__tbl_User__7C1FCE5FCD744D18");

            entity.ToTable("tbl_User");

            entity.Property(e => e.PkUserId).HasColumnName("PK_UserID");
            entity.Property(e => e.EmailId)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("EmailID");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
