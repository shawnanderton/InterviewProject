using System;
using System.Collections.Generic;
using Web.Models;

namespace Web.DAL
{
    public interface IUserRepository
   {
      IEnumerable<User> GetUsers();
      User GetUserByID(int userId);
      void InsertUser(User user);
      void DeleteUser(int userId);
      void UpdateUser(int id, User user);
      
   }
}
