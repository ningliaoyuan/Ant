using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Ant.Models;
using Ant.Models.Account;

namespace Ant.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {

        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn()
        {
            return View();
        }
        /// <summary>
        /// 1.发送完整的登录表单：
        /// 发：用户名（邮箱地址或者昵称），密码，是否自动登录
        /// 回：“ok”or“error:用户密码错误”or“error:邮箱地址不存在”or“error:用户昵称不存在” 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AjaxLogOn(LogOnModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    return this.AjaxOK();
                }
                else
                {
                    return this.AjaxError("用户名不存在或密码输入错误，请重试");
                }
            }

            return this.Ajax();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            FormsService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        /// <summary>
        /// 发送完整注册表单：
        /// 发：邮箱地址，昵称，密码
        /// 回：“ok”or“error:邮箱地址已经被注册了”or“error:此用户昵称已经被注册了”or“error:邮箱地址不符合规范”or“error:用户昵称最多8个中文字符或者16个英文字符”or“error:密码至少需要6个字符” 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AjaxRegister(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    return this.AjaxOK();
                }
                else
                {
                    return this.AjaxError(AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            return this.Ajax();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(ForgetPasswordModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var username = Membership.GetUserNameByEmail(model.Email);
                if (!string.IsNullOrEmpty(username))
                {
                    var user = Membership.GetUser(username, false);
                    if (user.Email == model.Email)
                    {
                        EmailAdmin.SendResetPasswordLink(user.Email, user.UserName, ResetPasswordModel.CookResetHash(user.UserName));
                        if (!String.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("ForgetPasswordDone", model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "用户名与邮箱地址不匹配。");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "用户名不存在。");
                }
            }
               

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult ForgetPasswordDone(ForgetPasswordModel model)
        {
            return View(model);
        }

        public ActionResult ResetPassword(string username, string k)
        {
            var m = new ResetPasswordModel() { username = username, k = k };
            return View(m);            
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordModel m)
        {
            if (ModelState.IsValid && m.Validate())
            {
                var user = Membership.GetUser(m.username);
                
                if (user.ChangePassword(user.ResetPassword(),m.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "出错啦，联系管理员");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(m);
        }


        /// <summary>
        /// 用户邮箱地址验证：
        /// <summary>
        /// 用户邮箱地址验证：
        /// 发：邮箱地址
        /// 回：“ok”or“error:邮箱地址已经被注册了”or“error:邮箱地址不符合规范” 
        /// </summary>
        public ActionResult AjaxEmailCheck(string email)
        {
            var user = Membership.GetUserNameByEmail(email);
            if(string.IsNullOrEmpty(user))
            {
                return this.AjaxOK();
            }
            else
            {
                return this.AjaxError("邮箱地址已经被注册了");
            }
        }

        /// <summary>
        /// 用户昵称验证：
        /// <summary>
        /// 用户昵称验证：
        /// 发：昵称 
        /// 回：“ok”or“error:此用户昵称已经被注册了”or“error:用户昵称最多8个中文字符或者16个英文字符” 
        /// </summary>
        public ActionResult AjaxNickCheck(string username)
        {
            var user = Membership.GetUser(username, false);
            if (user == null)
            {
                return this.AjaxOK();
            }
            else
            {
                return this.AjaxError("此用户昵称已经被注册了");
            }
        }

        public ActionResult AjaxPartLogon()
        {
            return PartialView("LogOnUserControl");
        }

    }
}
