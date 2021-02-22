using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Repo
{
    public interface IUserRepo
    {
        public List<User> GetAllUsers();
        public User GetUserByEmail(string email);
        public User GetUserByName(string name);
        public  bool RegisterUser(User user);
    }
}
