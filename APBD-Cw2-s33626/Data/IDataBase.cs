using APBD_Cw2_s33626.Models;

namespace APBD_Cw2_s33626.Data;

public interface IDataBase
{
    List<Rental> Rentals { get; }
    List<User> Users { get; }
    List<Device> Devices { get; }
    
}