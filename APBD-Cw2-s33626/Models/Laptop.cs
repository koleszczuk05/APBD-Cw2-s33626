namespace APBD_Cw2_s33626.Models;

public class Laptop(string name, double dayCost, string os, int ramSize) : Device(name, dayCost)
{
    public string Os  { get; set; } = os;
    public int RamSize { get; set; } = ramSize;
}