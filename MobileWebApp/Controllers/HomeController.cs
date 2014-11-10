using MobileWebApp.Models;
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
                UserRegister userRegister = new UserRegister();
                userRegister.UserRegisterId = Guid.NewGuid();
                userRegister.FirstName = "First 1";
                userRegister.LastName = "Last 1";
                userRegister.Gender = "Male";
                userRegister.Birthday = "01-01-2001";
                userRegister.Phone = "(007) 007-1001";
                userRegister.UserName = "user123";
                userRegister.UserPassword = "pass123";
                userRegister.EmailAddress = "user123@gmail.com";
                userRegister.FavoriteFood = "paella 1";
                userRegister.FavoriteDrink = "coffee 1";
                _repositoryUserRegister.Add(userRegister);
                userRegister = new UserRegister();
                userRegister.UserRegisterId = Guid.NewGuid();
                userRegister.FirstName = "First 2";
                userRegister.LastName = "Last 2";
                userRegister.Gender = "Female";
                userRegister.Birthday = "02-02-2002";
                userRegister.Phone = "(007) 007-1002";
                userRegister.UserName = "user234";
                userRegister.UserPassword = "pass234";
                userRegister.EmailAddress = "user234@gmail.com";
                userRegister.FavoriteFood = "paella 2";
                userRegister.FavoriteDrink = "coffee 2";
                _repositoryUserRegister.Add(userRegister);
            }
            ListUserRegistersViewModel userRegisterViewModel = new ListUserRegistersViewModel();
            userRegisterViewModel.UserRegisters = (from u in _repositoryUserRegister.GetUserRegisters()
                                         orderby u.UserName
                                         select new UserRegister
                                         {
                                             UserRegisterId = u.UserRegisterId,
                                             FirstName = u.FirstName,
                                             LastName = u.LastName,
                                             Gender = u.Gender,
                                             Birthday = u.Birthday,
                                             Phone = u.Phone,
                                             UserName = u.UserName,
                                             UserPassword = u.UserPassword,
                                             EmailAddress = u.EmailAddress,
                                             FavoriteFood = u.FavoriteFood,
                                             FavoriteDrink = u.FavoriteDrink
                                         }).ToList();
            //

            return View(userRegisterViewModel);
        }
	}
}