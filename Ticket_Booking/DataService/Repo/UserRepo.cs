using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataService.Repo
{
    public class UserRepo : IUserRepo
    {

        private readonly ApplicationdbContext _applicationdbcontext;
        public UserRepo(ApplicationdbContext applicationdbContext)
        {
            _applicationdbcontext = applicationdbContext;
        }
        
        public List<User> GetAllUsers()
        {
            return _applicationdbcontext.Users.ToList();
        }

        public User GetUserByEmail(string email)
        {
            var user= _applicationdbcontext.Users.FirstOrDefault(p => p.email == email);
            return user;
        }

        public User GetUserByName(string name)
        {
            var user = _applicationdbcontext.Users.FirstOrDefault(p => p.user_name == name);
            return user;
        }


        public bool RegisterUser(User user)
        {

            _applicationdbcontext.Users.Add(user);
            _applicationdbcontext.SaveChanges();
            return true;

        }

        public bool CheckEmail(User user)
        {
            var emailExists = _applicationdbcontext.Users.FirstOrDefault(p => p.email == user.email);
            if (emailExists == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
