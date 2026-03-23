using APBD_Cw2_s33626.Data;
using APBD_Cw2_s33626.Enums;
using APBD_Cw2_s33626.Models;

namespace APBD_Cw2_s33626.Services.Rentals;

public class RentalService(DataBase dataBase) : IRentalService 
{
    public void RentDevice(int userId, int deviceId, DateTime startDate, DateTime endDate)
    {
        var countRentals = 0;
        User? userAct = null;
        Device? deviceAct = null;
        foreach (var user in dataBase.Users)
        {
            if (user.Id == userId)
            {
                userAct = user;
            }
        }
        
        foreach (var rental in dataBase.Rentals)
        {
            if (rental.User.Id == userId && rental.ActDate == null)
            {
                countRentals++;
            }
        }

        foreach (var device in dataBase.Devices)
        {
            if (device.Id == deviceId)
            {
                deviceAct = device;
            }
        }

        if (deviceAct == null || userAct == null)
        {
            throw new ArgumentException("Device or User Not Found");
        }

        if (deviceAct.Status != DeviceStatus.Available)
        {
            throw new ArgumentException("Device not available");
        }

        if (countRentals == userAct.MaxItems)
        {
            throw new ArgumentException($"User {userId} is already renting max number of devices");
        }
        else if (userAct.MaxItems > countRentals)
        {
            var rental = new Rental(deviceAct, userAct, startDate, endDate);
            deviceAct.Status = DeviceStatus.Rented;
            dataBase.Rentals.Add(rental);
        }
    }

    public void ReturnDevice(int userId, int deviceId, DateTime returnDate)
    {
        throw new NotImplementedException();
    }

    public void ListOverDueDevices()
    {
        throw new NotImplementedException();
    }

    public void CreateRentingRaport()
    {
        throw new NotImplementedException();
    }
}