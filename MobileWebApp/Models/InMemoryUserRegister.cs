using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileWebApp.Models
{
    public class InMemoryUserRegister
    {
        private static List<AddRegistration> _userRegisters;
        private static InMemoryUserRegister _instance = null;
        private static readonly object Lock = new object();

        private InMemoryUserRegister()
        {
            _userRegisters = new List<AddRegistration>();            
        }

        public static InMemoryUserRegister GetInstance()
        {
            if (_instance == null)
            {
                _instance = new InMemoryUserRegister();
            }
            return _instance;
        }

        public IQueryable<AddRegistration> UserRegisters
        {
            get
            {
                return _userRegisters.AsQueryable();
            }
        }

        public void Add(AddRegistration userRegister)
        {
            lock (Lock)
            {
                _userRegisters.Add(userRegister);
            }
        }

        public void Remove(AddRegistration userRegister)
        {
            lock (Lock)
            {
                _userRegisters.Remove(userRegister);
            }
        }

        public void ClearAll()
        {
            lock (Lock)
            {
                for (int i = _userRegisters.Count - 1; i >= 0; i--)
                {
                    _userRegisters.RemoveAt(i);
                }
            }
        }
    }
}