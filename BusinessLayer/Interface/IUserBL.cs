using ModelLayer;
using RepoLayer.Entity;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public UserEntity AddUserDetail(UserModel userModel);

        //public UserEntity ViewDetail(string Email, string Password);

        public string UserLogin(UserLogin userLogin);


    }
}
