using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Location.Api.Entities.Models;

public class Building
{
    public int Id { get; set; }
    public int FKey { get; set; }
    public string? Block { get; set; }

    public string? Attribute { get; set; }

    [NotMapped] public MultiPolygon geom { get; set; }
    //[NotMapped] public MultiPolygon? geom { get; set; }
}