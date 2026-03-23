namespace APBD_Cw2_s33626.Services.Rentals;

public interface IRentalService
{
    //5
    public void RentDevice(int userId, int deviceId, DateTime startDate, DateTime endDate);
    //6
    public void ReturnDevice(int userId, int deviceId, DateTime returnDate);
    //9
    public void ListOverDueDevices();
    //10
    public void CreateRentingRaport();

}