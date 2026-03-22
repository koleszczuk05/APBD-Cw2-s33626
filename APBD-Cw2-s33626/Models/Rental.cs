namespace APBD_Cw2_s33626.Models;

public class Rental(Device device, User user, DateTime startDate, DateTime endDate)
{
    private static int _rentalId = 1;
    public DateTime? ActDate { get; set; } = null;
    public int Id { get; set; } = _rentalId++;
    public Device Device { get; set; } = device;
    public User User { get; set; } = user;
    public DateTime StartDate { get; set; } = startDate >= endDate ? throw new ArgumentException("Invalid time range") : startDate;
    public DateTime EndDate { get; set; } = endDate;
    public double Penalty { get; set; } = 0;
    
}