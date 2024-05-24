using PageDrift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PageDrift.Controllers
{
    public class AccountController : Controller
    {
        BookStoreDBContext dc = new BookStoreDBContext();

        #region Login
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(User user)
        {
            try
            {
                bool Isvalid = dc.users.Any(u => u.UserName == user.UserName && u.Password == user.Password);
                if (Isvalid)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("DisplayBooks", "Books");
                }
                else
                {
                    ModelState.AddModelError("", "Username and Password is incorrect");
                }
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Signup

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User user)
        {
            try
            {
                if (user.UserName != null && user.Password != null && user.Email != null)
                {
                    dc.users.Add(user);
                    try
                    {
                        dc.SaveChanges();
                        return RedirectToAction("Login");
                    }
                    catch
                    {
                        ModelState.AddModelError("", "Username and Password is incorrect");
                        return View();
                    }

                }
                else
                {

                }
                return View();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region LogOut
        public RedirectToRouteResult LogOut()
        {
            try
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("LogIn");
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion
    }
}