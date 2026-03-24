using APBD_Cw2_s33626.Data;
using APBD_Cw2_s33626.Models;
using APBD_Cw2_s33626.Services.Devices;
using APBD_Cw2_s33626.Services.Rentals;
using APBD_Cw2_s33626.Services.Users;

var db = new DataBase();
var rentalService = new RentalService(db);
var deviceService = new DeviceService(db);
var userService = new UserService(db);
deviceService.AddDevice(new Laptop("MacBook Pro", 100.0, "macOS", 16));
deviceService.AddDevice(new Camera("Sony A7", 70.0, "35mm", 24));
deviceService.AddDevice(new Projector("Epson X1", 40.0, "FullHD", 3000));

userService.AddUser(new Student("Jan", "Kowalski", "s12345"));
userService.AddUser(new Employee("Adam", "Nowak", 5000.0));
rentalService.RentDevice(1,1,DateTime.Now,DateTime.Now.AddDays(3));

try
{
    rentalService.RentDevice(2,1,DateTime.Now,DateTime.Now.AddDays(2));
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    rentalService.RentDevice(1,2,DateTime.Now,DateTime.Now.AddDays(2));
    rentalService.RentDevice(1,3,DateTime.Now,DateTime.Now.AddDays(1));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

rentalService.ReturnDevice(1,2,DateTime.Now);
rentalService.ReturnDevice(1,1,DateTime.Now.AddDays(10));

rentalService.CreateRentingRaport();
