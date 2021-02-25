using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Repo
{
    public interface IUserRepo
    {
         List<User> GetAllUsers();
         User GetUserByEmail(string email);
         User GetUserById(int id);
         bool RegisterUser(User user);    
    }
}
