using _4_EfCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4_EfCore.Repositories.Config;

public class BuildingConfig : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.HasData(
            new Building { Id = 1, FKey = 1, Block = "b1", Attribute = "n1" },
            new Building { Id = 2, FKey = 2, Block = "b2", Attribute = "n2" }
        );
    }
}