namespace _4_EfCore.Models;

public class Parcel
{
    public int Id { get; set; }
    public int ParcelNo { get; set; }
    public string Layout { get; set; } = string.Empty;
    public int Island { get; set; }
    public string Province { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Neighbourhood { get; set; } = string.Empty;
    public string Attribute { get; set; } = string.Empty;
}