using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PrjEcommersProyect.Models
{
    public partial class EcommersProyectContext : DbContext
    {
        public EcommersProyectContext()
        {
        }

        public EcommersProyectContext(DbContextOptions<EcommersProyectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<VentaProducto> VentaProductos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost;database=EcommersProyect;integrated security=true;");
            }
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A1025759655");

                entity.Property(e => e.NombreCategoria)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__098892105FFB8147");

                entity.Property(e => e.Marca)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Productos__IdCat__398D8EEE");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.NroReg)
                    .HasName("PK__Usuarios__50FD0B0D2521732C");

                entity.Property(e => e.NroReg).HasColumnName("nro_reg");

                entity.Property(e => e.ClaveUsu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("clave_usu");

                entity.Property(e => e.LoginUsu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("login_usu");
            });

            modelBuilder.Entity<VentaProducto>(entity =>
            {
                entity.HasKey(e => e.IdVentaProductos)
                    .HasName("PK__VentaPro__C9EAF700C3CEAAB2");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
