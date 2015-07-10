using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Web.Models;


namespace Web.DAL
{
    public class UserRepository : IUserRepository
   {

        public IEnumerable<User> GetUsers()
        {
            return UserData.Users;
        }
     

      public User GetUserByID(int userId)
      {
          return UserData.Users.FirstOrDefault(u => u.UserID == userId);
      }

      public void InsertUser(User user)
      {
          user.UserID = UserData.Users.Count;
          UserData.Users.Add(user);
      }

      public void DeleteUser(int userId)
      {
          var user = GetUserByID(userId);
          UserData.Users.Remove(user);
      }

      public void UpdateUser(int id, User user)
      {

          var userOld = GetUserByID(id);
          userOld.FirstName = user.FirstName;
          userOld.LastName = user.LastName;

      }



     

      
   }
}
