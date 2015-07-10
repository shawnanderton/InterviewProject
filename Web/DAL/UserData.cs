using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.DAL
{
    public static class UserData
    {
        public static List<User> Users = new List<User>{
           {new User{UserID =1, FirstName="John", LastName="Doe"}},
           {new User{UserID =2, FirstName="John2", LastName="Doe2"}},
           {new User{UserID =3, FirstName="John3", LastName="Doe3"}},
           {new User{UserID =4, FirstName="John4", LastName="Doe4"}},
           {new User{UserID =5,  FirstName="Jane", LastName="Doe"}},
           {new User{UserID =6, FirstName="Jane2", LastName="Doe2"}},
           {new User{UserID =7, FirstName="Jane3", LastName="Doe3"}},
           {new User{UserID =8, FirstName="Jane4", LastName="Doe4"}}
       };

        
      
    }
}