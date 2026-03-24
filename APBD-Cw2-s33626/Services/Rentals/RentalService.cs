using APBD_Cw2_s33626.Data;
using APBD_Cw2_s33626.Enums;
using APBD_Cw2_s33626.Models;

namespace APBD_Cw2_s33626.Services.Rentals;

public class RentalService(IDataBase dataBase) : IRentalService 
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
        Rental rentalAct = null;
        foreach (var rental in dataBase.Rentals)
        {
            if (rental.User.Id == userId && rental.Device.Id == deviceId && rental.ActDate == null)
            {
                rentalAct = rental;
            }
        }

        if (rentalAct == null)
        {
            throw new ArgumentException("The User does not rent this device");
        }

        if (returnDate > rentalAct.EndDate)
        {
            var penalty = CalculatePenalty(rentalAct.EndDate, returnDate,rentalAct.Device);
            Console.WriteLine($"The device was returned after it was supposed to so your Penalty is {penalty}");
        }

        rentalAct.Device.Status = DeviceStatus.Available;
        rentalAct.ActDate = returnDate;
    }

    public void ListOverDueDevices()
    {
        foreach (var rental in dataBase.Rentals)
        {
            if (rental.EndDate < DateTime.Now && rental.ActDate == null)
            {
                Console.WriteLine($"{rental.User.Id} - {rental.Device.Name} is a rental that is overdue");
            }
        }
    }

    public void CreateRentingRaport()
    {
        Console.WriteLine("RAPORT OF THE RENTAL OFFICE");
        Console.WriteLine($"Number of users: {dataBase.Users.Count}");
        Console.WriteLine($"Number of devices: {dataBase.Devices.Count}");
        Console.WriteLine($"Number of active rentals: {dataBase.Rentals.Count(rental => rental.ActDate == null)}");
        Console.WriteLine($"Number of finished rentals: {dataBase.Rentals.Count(rental => rental.ActDate != null)}");
        Console.WriteLine($"Number of overdue rentals that was returned: {dataBase.Rentals.Count(rental => rental.ActDate != null && rental.ActDate >= rental.EndDate)}");
        Console.WriteLine($"Number of devices that are currently overdue: {dataBase.Rentals.Count(rental => rental.ActDate == null && rental.EndDate < DateTime.Now)}");
        
    }

    private double CalculatePenalty(DateTime endDate, DateTime actualEndDate, Device device)
    {
        return (actualEndDate - endDate).TotalDays * device.DayCost;
    }
}