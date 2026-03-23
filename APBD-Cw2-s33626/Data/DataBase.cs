using APBD_Cw2_s33626.Models;

namespace APBD_Cw2_s33626.Data;

public class DataBase()
{
    public List<Rental> Rentals { get; set; } = [];
    public List<User> Users { get; set; } = [];
    public List<Device> Devices { get; set; } = [];
}