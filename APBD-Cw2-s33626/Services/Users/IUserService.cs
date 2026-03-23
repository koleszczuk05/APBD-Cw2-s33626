using APBD_Cw2_s33626.Models;

namespace APBD_Cw2_s33626.Services.Users;

public interface IUserService
{
    public void AddUser(User user);
    public void ListUserRentals(int userId);
}