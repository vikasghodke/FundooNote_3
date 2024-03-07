using ModelLayer;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public UserEntity AddUserDetail(UserModel userModel);

        //public UserEntity ViewDetail(string Email, string Password);

        public string UserLogin(UserLogin userLogin);
    }
}
