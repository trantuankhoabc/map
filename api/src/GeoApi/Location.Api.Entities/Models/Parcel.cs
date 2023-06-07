using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Location.Api.Entities.Models;

public class Parcel
{
    public int Id { get; set; }
    public int ParcelNo { get; set; }
    public string? Layout { get; set; }
    public int Island { get; set; }
    public string? Province { get; set; }
    public string? District { get; set; }
    public string? Neighbourhood { get; set; }
    public string? Attribute { get; set; }

    [NotMapped] public MultiPolygon? geom { get; set; }
}