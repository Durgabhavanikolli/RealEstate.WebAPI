using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Model;

namespace RealEstate.Infrastructure
{
    public partial class RealEstateDBContext : DbContext
    {
        /// <summary>
        /// RealEstateDBContext
        /// </summary>
        public RealEstateDBContext()
        {
        }

        /// <summary>
        /// RealEstateDBContext
        /// </summary>
        /// <param name="options"></param>
        public RealEstateDBContext(DbContextOptions<RealEstateDBContext> options)
            : base(options)
        {
           
        }

        /// <summary>
        /// LeadStatus
        /// </summary>
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<RealEstateDetail> RealEstateDetails { get; set; }
        /// <summary>
        /// OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!string.IsNullOrEmpty(_testDBName))
            //{
            //    optionsBuilder.UseInMemoryDatabase(_testDBName);
            //    base.OnConfiguring(optionsBuilder);
            //}
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("('1')");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                   .HasMaxLength(250)
                   .IsUnicode(false);
                entity.Property(e => e.Email)
                   .HasMaxLength(250)
                   .IsUnicode(true);
                entity.Property(e => e.MobileNumber)
                   .HasMaxLength(10)
                   .IsUnicode(true);
                entity.Property(e => e.Password)
                   .HasMaxLength(250)
                   .IsUnicode(false);
            });

            modelBuilder.Entity<RealEstateDetail>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("('1')");

                entity.Property(e => e.Name)
                    .HasMaxLength(250);
                entity.Property(e => e.City)
                   .HasMaxLength(250);
                entity.Property(e => e.Location)
                   .HasMaxLength(250);
                entity.Property(e => e.NoProjectsCompleted);
            });
            // Call the base class implementation
            base.OnModelCreating(modelBuilder);
        }

    }
}