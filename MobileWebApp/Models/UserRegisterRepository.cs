using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models
{
    public class UserRegisterRepository : IUserRegisterRepository
    {
        private InMemoryUserRegister _instance;

        public UserRegisterRepository()
        {
            _instance = InMemoryUserRegister.GetInstance();
        }

        public bool Add(UserRegister userRegister)
        {
            var flag = false;
            try
            {
                _instance.Add(userRegister);
                flag = true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;                
            }
            return flag;
        }

        public bool Delete(Guid id)
        {
            var flag = false;
            try
            {
                var userRegister = _instance.UserRegisters.FirstOrDefault(r => r.UserRegisterId == id);
                if (userRegister != null)
                {
                    _instance.Remove(userRegister);
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;                
            }
            return flag;
        }

        public UserRegister GetUserRegister(Guid id)
        {
            var userRegister = _instance.UserRegisters.FirstOrDefault(r => r.UserRegisterId == id);
            return userRegister;
        }

        public IEnumerable<UserRegister> GetUserRegisters()
        {
            return _instance.UserRegisters;            
        }

        public void ClearAll()
        {
            _instance.ClearAll();
        }
    }
}