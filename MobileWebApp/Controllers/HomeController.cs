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
                userRegister.DeviceType = 1;
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
                userRegister.DeviceType = 2;
                userRegister.TextMsg = "False";                
                userRegister.Password = "pass234";
                userRegister.Email = "user234@gmail.com";               
                _repositoryUserRegister.Add(userRegister);
                userRegister = new AddRegistration();
                userRegister.UserId = Guid.NewGuid();
                userRegister.Firstname = "Bob";
                userRegister.Lastname = "Bouma";
                userRegister.Birthday = "12/12";
                userRegister.Phone = "(007) 007-1002";
                userRegister.DeviceType = 2;
                userRegister.TextMsg = "False";
                userRegister.Password = "bbouma";
                userRegister.Email = "bbouma@we-are-pos.com";
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

        public void Buy()
        {
            string firstName = Request.QueryString["firstName"];
            string lastName = Request.QueryString["lastName"];
            
            HCService.HCServiceSoapClient client = new HCService.HCServiceSoapClient();
            HCService.InitPaymentRequest req = new HCService.InitPaymentRequest();
            req.MerchantID = "935839278044253";
            req.Password = "Rz%9NqTDGDcwxcMQ";
            req.Invoice = "1234";
            req.TotalAmount = 1.23;
            req.TaxAmount = 0;
            req.TranType = "Sale";
            req.Frequency = "OneTime";
            req.Memo = "dano test";

            req.ProcessCompleteUrl = "http://mobilewebapp.apphb.com/Home/Complete";
            req.ReturnUrl = "http://mobilewebapp.apphb.com/Home/Cancel";
            //req.ProcessCompleteUrl = "http://localhost:4094/Home/Complete";
            //req.ReturnUrl = "http://localhost:4094/Home/Cancel";
            
            req.OperatorID = "test";
            req.DisplayStyle = "custom";
            req.CancelButton = "on";
            var resp = client.InitializePayment(req);

            //ViewBag.URL = "https://hc.mercurydev.net/CheckoutIFrame.aspx?ReturnMethod=get&pid=" + resp.PaymentID;
            //return View();

            //Check the responseCode 
            if (resp.ResponseCode == 0)
            {
                var hostedCheckoutURL = "https://hc.mercurydev.net/mobile/mCheckout.aspx";
                //var hostedCheckoutURL = "https://hc.mercurydev.net/Checkout.aspx"; 
                Response.Clear();
                Response.Write("<html><head>");
                Response.Write("</head><body onload=\"document.frmCheckout.submit()\">");
                Response.Write("<h1>Mercury Pay Redirect Page</h1>");
                Response.Write("<h4>Put loading indicator here when needed</h4>");
                Response.Write("<h2>Please wait...You're being redirected to Mercury Pay</h2>");
                Response.Write("<form name=\"frmCheckout\" method=\"Post\" action=\"" + hostedCheckoutURL + "\">");
                Response.Write("<input name=\"PaymentID\" type=\"hidden\" value=\"" + resp.PaymentID + "\">");
                Response.Write("</form>");
                Response.Write("</body></html>");
                Response.End();
            }
            else
            {

            }

        }

        public ActionResult Cancel(string PaymentID, int ReturnCode, string ReturnMessage)
        {
            ViewData["PaymentID"] = PaymentID;
            ViewData["ReturnCode"] = ReturnCode;
            ViewData["ReturnMessage"] = ReturnMessage;
            return View();
        }

        public ActionResult Complete(string PaymentID, int ReturnCode, string ReturnMessage)
        {
            //HCService.HCServiceSoapClient client = new HCService.HCServiceSoapClient();
            //HCService.PaymentInfoRequest req = new HCService.PaymentInfoRequest();
            //req.MerchantID = "935839278044253";
            //req.Password = "Rz%9NqTDGDcwxcMQ";
            //req.PaymentID = PaymentID;
            //var resp = client.VerifyPayment(req);

            ViewData["PaymentID"] = PaymentID;
            ViewData["ReturnCode"] = ReturnCode;
            ViewData["ReturnMessage"] = ReturnMessage;
            return View();           
        }



	}
}