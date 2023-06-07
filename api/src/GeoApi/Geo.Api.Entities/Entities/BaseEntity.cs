using NetTopologySuite.Geometries;

namespace Geo.Api.Entities.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public Geometry Geometry { get; set; }
        public string Type { get; set; }
    }
}