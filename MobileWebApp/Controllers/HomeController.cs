using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileWebApp.Models;

namespace MobileWebApp.Controllers
{
    public class HomeController : Controller
    {
        private UserRegisterRepository _repositoryUserRegister;

        public HomeController()
        {
            _repositoryUserRegister = new UserRegisterRepository();
        }
        
        //
        // GET: /Home/
        public ActionResult Index()
        {
            //
            if (!_repositoryUserRegister.GetUserRegisters().Any())
            {
                _repositoryUserRegister.ClearAll();
                AddRegistration userRegister = new AddRegistration();
                userRegister.UserId = Guid.NewGuid();
                userRegister.Firstname = "First 1";
                userRegister.Lastname = "Last 1";                
                userRegister.Birthday = "01/01";                
                userRegister.Phone = "(007) 007-1001";
                userRegister.DeviceType = 2;
                userRegister.TextMsg = "True";                
                userRegister.Password = "pass123";
                userRegister.Email = "user123@gmail.com";              
                _repositoryUserRegister.Add(userRegister);
                userRegister = new AddRegistration();
                userRegister.UserId = Guid.NewGuid();
                userRegister.Firstname = "First 2";
                userRegister.Lastname = "Last 2";                
                userRegister.Birthday = "02/02";            
                userRegister.Phone = "(007) 007-1002";
                userRegister.DeviceType = 1;
                userRegister.TextMsg = "False";                
                userRegister.Password = "pass234";
                userRegister.Email = "user234@gmail.com";               
                _repositoryUserRegister.Add(userRegister);
            }
            ListUserRegistersViewModel userRegisterViewModel = new ListUserRegistersViewModel();
            userRegisterViewModel.UserRegisters = (from u in _repositoryUserRegister.GetUserRegisters()
                                         //orderby u.UserName
                                         orderby u.Email
                                         select new AddRegistration
                                         {
                                             UserId = u.UserId,
                                             Firstname = u.Firstname,
                                             Lastname = u.Lastname,                                             
                                             Birthday = u.Birthday,                                            
                                             Phone = u.Phone,
                                             DeviceType = u.DeviceType,
                                             TextMsg = u.TextMsg,                                             
                                             Password = u.Password,
                                             Email = u.Email                                          
                                         }).ToList();
            //

            return View(userRegisterViewModel);
        }
	}
}