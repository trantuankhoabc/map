using Location.Api.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Location.Api.Repositories.EfCore.Config;

public class ParcelConfig : IEntityTypeConfiguration<Parcel>
{
    public void Configure(EntityTypeBuilder<Parcel> builder)
    {
        builder.HasData(
            new Parcel
            {
                Id = 1, ParcelNo = 1, Layout = "p1", Island = 1, Province = "il1", District = "ilce1",
                Neighbourhood = "m1", Attribute = "n1"
            },
            new Parcel
            {
                Id = 2, ParcelNo = 2, Layout = "p2", Island = 2, Province = "il2", District = "ilce2",
                Neighbourhood = "m2", Attribute = "n2"
            }
        );
    }
}