using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWebApp.Models
{
    public interface IUserRegisterRepository
    {
        bool Add(UserRegister userRegister);
        bool Delete(Guid id);
        UserRegister GetUserRegister(Guid id);
        IEnumerable<UserRegister> GetUserRegisters();
        void ClearAll();
    }
}
