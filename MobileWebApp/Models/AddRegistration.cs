using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models
{
    public class AddRegistration
    {
        public AddRegistration()
        {
            Profiles = new List<AddProfile>();
        }
        
        public int SiteId { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DeviceType { get; set; }
        //public string UserId { get; set; }
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string TextMsg { get; set; }
        public IList<AddProfile> Profiles { get; set; }
    }
}