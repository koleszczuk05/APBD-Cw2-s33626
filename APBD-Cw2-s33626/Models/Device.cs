namespace APBD_Cw2_s33626.Models;
using APBD_Cw2_s33626.Enums;

public abstract class Device(string name, double dayCost)
{
    private static int idDevice = 1;

    public int Id { get; } =  idDevice++;
    public string Name { get; set; } = name;
    public string Description { get; set; } = "";
    public double DayCost { get; set; } = dayCost;
    public DeviceStatus Status { get; set; } = DeviceStatus.Available;
}