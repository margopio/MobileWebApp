using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models
{
    public class GetUserRegisterViewModel
    {
        public UserRegister UserRegister { get; set; }
    }

    public class ListUserRegistersViewModel
    {
        public IEnumerable<AddRegistration> UserRegisters { get; set; }
    }
}