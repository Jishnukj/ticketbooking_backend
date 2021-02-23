using DataService.Entities;
using DataService.Repo;
using System;
using System.Collections.Generic;
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
            var emailAlreadyExists = _userRepo.CheckEmail(user);

            if (emailAlreadyExists == false)
            {
                if (user.user_type.Equals("Admin"))
                {
                    var adminExists = _userRepo.AdminExists();
                    if (adminExists == false)
                        return _userRepo.RegisterUser(user);
                    else
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
            var emailAlreadyExists = _userRepo.CheckEmail(user);

            if (emailAlreadyExists == false)
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
    }
}
