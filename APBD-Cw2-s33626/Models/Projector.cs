namespace APBD_Cw2_s33626.Models;

public class Projector(string name, double dayCost, string resolution, int lumens) : Device(name,dayCost)
{
    public string Resolution { get; set; } = resolution;
    public int Lumens { get; set; } = lumens;
    
}