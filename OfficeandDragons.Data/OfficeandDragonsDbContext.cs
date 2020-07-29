using Microsoft.EntityFrameworkCore;


namespace OfficeandDragons.Data
{
    public class OfficeandDragonsDbContext : DbContext
    {
        public OfficeandDragonsDbContext()
        {
        }

        public OfficeandDragonsDbContext(DbContextOptions<OfficeandDragonsDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
		public virtual DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CompanyConfiguration());

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                builder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }
        }
    }
}