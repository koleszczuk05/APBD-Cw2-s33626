namespace APBD_Cw2_s33626.Models;

public class Camera(string name, double dayCost, string lensType, int megaPixelCount ) : Device(name, dayCost)
{
    public string LensType { get; set; } = lensType;
    public int MegaPixelCount { get; set; } = megaPixelCount;
}