using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OfficeandDragons.Data
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(c => c.UserEmail).IsRequired().HasMaxLength(100);
            builder.HasIndex(c => new { c.UserEmail }).IsUnique(false);
            builder.HasIndex(c => new { c.Name }).IsUnique(true);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
        }
    }
}