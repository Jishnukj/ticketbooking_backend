using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessService
{
    public interface IUserService
    {
        bool RegisterUser(User user);
        bool LoginUser(string email, string password);
        User GetUserById(int id);
        List<User> GetAllUsers();
        bool RegisterAdmin(User user);
        string checkAdmin(string email, string password);
    }
}
