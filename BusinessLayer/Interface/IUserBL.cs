using ModelLayer;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        //public UserEntity AddUserDetail(UserModel userModel);
        public UserModel AddUserDetail(UserModel userModel);
        //public UserEntity ViewDetail(string Email, string Password);
        public string UserLogin(UserLogin userLogin);

        public Task<string> ForgetPass(string email);

        public Task<string> ResetPassword(string Password1, int userID);
    }
}
