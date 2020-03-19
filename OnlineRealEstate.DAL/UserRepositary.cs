using OnlineRealEstate.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRealEstate.DAL
{
    public class UserRepositary
    {
        List<User> userList = new List<User>();
        public int SignUp(User user)
        {
            PropertyContext propertyContext = new PropertyContext();
            propertyContext.User.Add(user);
            return propertyContext.SaveChanges();
        }
        public string Login(User user)
        {
            PropertyContext propertyContext = new PropertyContext();
            user = propertyContext.User.Where(userDetail=>userDetail.Email==user.Email && userDetail.Password==user.Password).FirstOrDefault();
            return user.Role;
         
        }
    }
}
