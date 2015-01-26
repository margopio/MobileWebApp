using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWebApp.Models
{
    public interface IUserRegisterRepository
    {
        bool Add(AddRegistration userRegister);
        bool Delete(Guid id);
        AddRegistration GetUserRegister(Guid id);
        IEnumerable<AddRegistration> GetUserRegisters();
        void ClearAll();
    }
}
