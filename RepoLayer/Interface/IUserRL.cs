﻿using ModelLayer;

namespace RepoLayer.Interface
{
    public interface IUserRL
    {
        //public UserEntity AddUserDetail(UserModel userModel);
        public UserModel AddUserDetail(UserModel userModel);
        //public UserEntity ViewDetail(string Email, string Password);
        public string UserLogin(UserLogin userLogin);

        public string ForgetPassword(Reset_PasswordModel resetPasswordModel);
    }
}
