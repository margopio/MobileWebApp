using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models
{
    public class UserRegister
    {
        public Guid UserRegisterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string EmailAddress { get; set; }
        public string FavoriteFood { get; set; }
        public string FavoriteDrink { get; set; }        
    }
}