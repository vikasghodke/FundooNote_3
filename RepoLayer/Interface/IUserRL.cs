using ModelLayer;
using System.Threading.Tasks;

namespace RepoLayer.Interface
{
    public interface IUserRL
    {
        
        public UserModel AddUserDetail(UserModel userModel);
        
        public string UserLogin(UserLogin userLogin);

        public Task<string> ForgetPass(string Email);

        public Task<string> ResetPassword(string Password1, int userID);



        /* public string ForgetPassword(Reset_PasswordModel resetPasswordModel);
        public string ResetPassword(Reset_PasswordModel reset_PasswordModel);*/
    }
}
