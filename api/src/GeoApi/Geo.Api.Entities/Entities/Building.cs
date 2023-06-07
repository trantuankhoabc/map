using System.ComponentModel.DataAnnotations.Schema;

namespace Geo.Api.Entities.Entities
{
    public class Building : BaseEntity
    {
        public string Osm_Id { get; set; }
        public string LastChange { get; set; }
        public int Code { get; set; }
        public string FClass { get; set; }
        public char GeomType { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Levels { get; set; }
        [Column("building_type")]
        public string BuildingType { get; set; }
    }
}
