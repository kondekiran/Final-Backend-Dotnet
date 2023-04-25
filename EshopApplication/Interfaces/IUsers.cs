using EshopApplication.Models;
using EshopApplication.Models.spModel;
using Models;

namespace EshopApplication.Interfaces
{
    public interface IUsers
    {
        List<Users> GetUsersList();
        Users RegisterUser(Users userData);
        Users UpdateProfile(Users userData);
        Users ValidateUser(LoginUser userData);
        Object GetUserDetailsById(int id);

        List<UsersOrdersList> AllOrdersList();
    
    }
}
