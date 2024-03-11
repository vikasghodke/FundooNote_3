using BusinessLayer.Interface;
using ModelLayer;
using RepoLayer.Interface;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        public readonly IUserRL userRL;

        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        //public UserEntity AddUserDetail(UserModel userModel)
        public UserModel AddUserDetail(UserModel userModel)
        {
            return userRL.AddUserDetail(userModel);
        }

        /* public UserEntity ViewDetail(string Email, string Password)
         {
             return userRL.ViewDetail(Email, Password);
         }*/
        public string UserLogin(UserLogin userLogin)
        {
            return userRL.UserLogin(userLogin);
        }
        public string ForgetPassword(Reset_PasswordModel resetPasswordModel)
        {
            return userRL.ForgetPassword(resetPasswordModel);
        }
    }
}
