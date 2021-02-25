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
                if (user.user_type.Equals("Admin"))
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

        public bool LoginUser(string email, string password)
        {
            var user = _userRepo.GetUserByEmail(email);
            if (user != null)
            {
                if (user.email == email && user.password == password)
                    return true;
                else
                    return false;
            }
            return false;
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

        public string checkAdmin(string email, string password)
        {
            var p = _userRepo.GetAllUsers();
            var data = p.Where(p => p.email == email && p.password == password).FirstOrDefault();
            if (data != null)
            {
                if (data.user_type == "admin" || data.user_type == "artist" || data.user_type == "user")
                {
                    return data.user_type;
                }
                else return "invalid_user";
            }
            else return "invalid_user";
        }
    }
}
