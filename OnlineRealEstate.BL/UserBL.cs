using OnlineRealEstate.DAL;
using OnlineRealEstate.Entity;

namespace OnlineRealEstate.BL
{
    public class UserBL
    {
        UserRepositary userRepositary = new UserRepositary();
        public int SignUp(User user)
        {
            return userRepositary.SignUp(user);
        }
        public string Login(User user)
        {
            return userRepositary.Login(user);
        }
      

    }
}
