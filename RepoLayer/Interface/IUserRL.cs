using ModelLayer;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IUserRL
    {
        public UserEntity AddUserDetail(UserModel userModel);

        public UserEntity ViewDetail(string Email, string Password);

        
    }
}
