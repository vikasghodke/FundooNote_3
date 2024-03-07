using BusinessLayer.Interface;
using Microsoft.AspNetCore.Identity;
using ModelLayer;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL :IUserBL
    {
        public readonly IUserRL userRL;

        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public UserEntity AddUserDetail(UserModel userModel)
        {
            return userRL.AddUserDetail(userModel);
        }

        public UserEntity ViewDetail(string Email, string Password)
        {
            return userRL.ViewDetail(Email, Password);
        }


    }
}
