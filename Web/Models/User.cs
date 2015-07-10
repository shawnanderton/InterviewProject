using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}