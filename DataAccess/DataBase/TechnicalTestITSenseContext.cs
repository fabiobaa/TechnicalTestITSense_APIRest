using Microsoft.EntityFrameworkCore;

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
