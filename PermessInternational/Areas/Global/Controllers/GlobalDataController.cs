using PermessInternational.Areas.Global.Interface;
using PermessInternational.Areas.Global.Models;
using PermessInternational.Areas.Global.Password;
using PermessInternational.Areas.Global.ViewModels;
using PermessInternational.PermessContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PermessInternational.Areas.Global.Controllers
{
    public class GlobalDataController : Controller
    {
        private readonly PermessDbContext _context;
        private readonly ISystemUser _system;
        public GlobalDataController(PermessDbContext context, ISystemUser system)
        {
            _context = context;
            _system = system;
        }
        public ActionResult Index()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return View();
            }
            return RedirectToAction(nameof(LogIn));
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(SystemUser systemUser)
        {
            var getuser = _context.SystemUsers.FirstOrDefault(m => m.EmailAddress == systemUser.EmailAddress);
            if (getuser != null)
            {
                Helper helper = new Helper();
                var hashSalt = getuser.HashSalt;
                var password = helper.HashPasswordUsingSHA2(systemUser.Password, hashSalt);
                var query = _context.SystemUsers.FirstOrDefault(m => m.EmailAddress == systemUser.EmailAddress && m.Password == password);
                if (query != null)
                {
                    Session["ConcernId"] = 1;
                    Session["UserId"] = Convert.ToInt32(query.UserID);
                    var userName = _context.UserRoles.FirstOrDefault(x => x.UserRoleId == query.UserRole);
                    Session["RoleName"] = Convert.ToString(userName.UserRoleName);
                    Session["RoleId"] = Convert.ToInt32(query.UserRole);
                    Session["UserName"] = Convert.ToString(query.Name);
                    return RedirectToAction("Index", "PermessData", new { Area = "Permess" });
                }
                ViewBag.error = "email or password wrong !";
            }

            return View();
        }
        [HttpGet]
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction(nameof(LogIn));
        }
        //[HttpPost]
        //public JsonResult LogIn(SystemUser systemUser)
        //{
        //    return Json(new { redirectUrl = Url.Action("Index", "Home"), isRedirect = true });
        //}
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        public ActionResult Users()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            var user = _system.Users(concernId);
            var role = _context.UserRoles.Where(x => x.ConcernId == concernId).ToList();
            SystemUserViewModels viewModels = new SystemUserViewModels()
            {
                SystemUsers = user,
                UserRoles = role
            };
            return View(viewModels);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var role = _context.UserRoles.Where(x => x.ConcernId == 1).ToList();
            RoleUserViewModels viewModels = new RoleUserViewModels()
            {
                UserRoles = role
            };
            return View(viewModels);
        }
        [HttpPost]
        public JsonResult AddUser(SystemUser systemUser)
        {
            var chkUser = _context.SystemUsers.FirstOrDefault(m => m.EmailAddress == systemUser.EmailAddress);
            if (chkUser == null)
            {
                var userId = Convert.ToInt32(Session["UserId"]);
                var concernId = Convert.ToInt32(Session["ConcernId"]);
                Helper helper = new Helper();
                var hashSalt = helper.GenerateRandomSalt();
                var password = helper.HashPasswordUsingSHA2(systemUser.Password, hashSalt);
                systemUser.Password = password;
                systemUser.CreatorId = userId;
                systemUser.ConcernID = concernId;
                systemUser.CreationDate = DateTime.Now;
                systemUser.LoginDate = DateTime.Now;
                systemUser.HashSalt = hashSalt;
                systemUser.ActivationDate = DateTime.Now;
                _context.SystemUsers.Add(systemUser);
                _context.SaveChanges();
                return Json("added successfully", JsonRequestBehavior.AllowGet);
            }
            return Json("User name or email already exists", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult EditUserRole(int id)
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var role = _context.UserRoles.Where(x => x.ConcernId == 1).ToList();
            var user = _context.SystemUsers.FirstOrDefault(x => x.UserID == id);
            RoleUserViewModels viewModels = new RoleUserViewModels()
            {
                UserRoles = role,
                SystemUser = user
            };
            return View(viewModels);
        }
        [HttpPost]
        public ActionResult EditUserRole(int id,SystemUser system)
        {
            var user = _context.SystemUsers.FirstOrDefault(x => x.UserID == id);
            user.EmailAddress = system.EmailAddress;
            user.Name = system.Name;
            user.UserRole = system.UserRole;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}