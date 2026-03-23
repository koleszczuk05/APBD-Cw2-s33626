using APBD_Cw2_s33626.Data;
using APBD_Cw2_s33626.Models;

namespace APBD_Cw2_s33626.Services.Users;

public class UserService(DataBase dataBase) : IUserService
{
    public void AddUser(User user)
    {
        if (!dataBase.Users.Contains(user))
        {
            dataBase.Users.Add(user);
        }
        else
        {
            throw new ArgumentException("User already exists");
        }
    }

    public void ListUserRentals(int userId)
    {
        foreach (var rental in dataBase.Rentals)
        {
            if (rental.User.Id == userId && rental.ActDate == null)
            {
                Console.WriteLine($"{rental.User.Id} - {rental.User.Name} - {rental.Device.Name}");
            }
        }
    }
}