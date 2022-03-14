using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess.DataBase
{
    public partial class TechnicalTestITSenseContext : DbContext
    {
        public TechnicalTestITSenseContext()
        {
        }

        public TechnicalTestITSenseContext(DbContextOptions<TechnicalTestITSenseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StatusProduct> StatusProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=technicaltestitsense.cw4lxxdosfvm.us-east-1.rds.amazonaws.com,1433;DataBase=TechnicalTestITSense;Integrated Security= false; User ID=admin;Password=test1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.idProduct);

                entity.ToTable("Product");

                entity.Property(e => e.dateEntryProduct).HasColumnType("datetime");

                entity.Property(e => e.dateExitProduct).HasColumnType("datetime");

                entity.Property(e => e.nameProduct)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.idStatusProductNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.idStatusProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_StatusProduct");
            });

            modelBuilder.Entity<StatusProduct>(entity =>
            {
                entity.HasKey(e => e.idStatusProduct);

                entity.ToTable("StatusProduct");

                entity.Property(e => e.nameStatusProduct)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
