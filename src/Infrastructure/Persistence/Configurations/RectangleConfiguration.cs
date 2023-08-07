using TestApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestApp.Infrastructure.Persistence.Configurations;

public class RectangleConfiguration : IEntityTypeConfiguration<Rectangle>
{
    public void Configure(EntityTypeBuilder<Rectangle> builder)
    {
        builder.HasOne(t => t.TopLeft);
        builder.HasOne(t => t.BottomRight);
    }
}
