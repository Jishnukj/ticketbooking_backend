using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessService
{
    public interface IUserService
    {
        bool RegisterUser(User user);
        User GetUserById(int id);
        List<User> GetAllUsers();
        bool RegisterAdmin(User user);
        User checkAdmin(string email, string password);
    }
}
