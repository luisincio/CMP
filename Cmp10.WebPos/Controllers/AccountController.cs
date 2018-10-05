#region Espacios de Nombres
using Cmp02.Entities;
using Cmp10.WebPos.Models;
using Cmp04.BusinessLogic;
using System.Web.Mvc;
using System.Web.Security;
#endregion

namespace Cmp10.WebPos.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        #region Métodos Públicos

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Session.Clear();
                FormsAuthentication.SignOut();

                var user = new Tb_Usuario_LN().GetRegistry(model.UserName, model.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Usuario.ToUpper(), false);
                    HttpContext.Session.Add("User", user);
                    Session.Add("Menu", new Tb_Permiso_LN().List(user.Id_Usuario));
                    Session.Timeout = 10800;
                    //Session["Menu"] = new Tb_Permiso_LN().List(user.Id_Usuario);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Usuario o contraseña incorrecta");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        #endregion
    }
}