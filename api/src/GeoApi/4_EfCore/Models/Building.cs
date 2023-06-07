namespace _4_EfCore.Models;

public class Building
{
    public int Id { get; set; }
    public int FKey { get; set; }
    public string Block { get; set; } = string.Empty;
    public string Attribute { get; set; } = string.Empty;
}