using DataService.Entities;
using DataService.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public bool RegisterUser(User user)
        {
            var emailAlreadyExists = _userRepo.GetUserByEmail(user.email);

            if (emailAlreadyExists == null)
            {
                if (user.user_type.ToLower().Equals("admin"))
                {
                   return false;
                }
                return _userRepo.RegisterUser(user);
            }
            else
            {
                return false;
            }
        }

        public bool RegisterAdmin(User user)
        {
            var emailAlreadyExists = _userRepo.GetUserByEmail(user.email);

            if (emailAlreadyExists == null)
            {
                return _userRepo.RegisterUser(user);
            }
            else
            {
                return false;
            }
        }

        public User GetUserById(int id)
        {
            var user = _userRepo.GetUserById(id);
            return user;
        }


        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public User checkAdmin(string email, string password)
        {
            var p = _userRepo.GetAllUsers();
            var data = p.Where(p => p.email == email && p.password == password).FirstOrDefault();
            if (data != null)
            {
                if (data.user_type == "admin" || data.user_type == "artist" || data.user_type == "user")
                {
                    return data;
                }
                else return null;
            }
            else return null;
        }
    }
}
