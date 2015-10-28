using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models.SIServiceRewards
{
    public class RegisterCommand
    {
        public RegisterCommand()
            {
                Profiles = new List<RegistrationProfile>();
                BeerProfiles = new List<RegistrationProfile>();
            }

            public int MemberKey { get; set; }
            public string IdCard { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public int DeviceType { get; set; }
            public IList<RegistrationProfile> Profiles { get; set; }
            public IList<RegistrationProfile> BeerProfiles { get; set; }
    }
}