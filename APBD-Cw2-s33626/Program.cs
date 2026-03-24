using APBD_Cw2_s33626.Data;
using APBD_Cw2_s33626.Services.Devices;
using APBD_Cw2_s33626.Services.Rentals;
using APBD_Cw2_s33626.Services.Users;

var db = new DataBase();
var rentalService = new RentalService(db);
var deviceService = new DeviceService(db);
var userService = new UserService(db);
