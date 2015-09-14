using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Tombola.Core.Data.Repository;
using MVCLINQTOSQL.Mapping;
namespace MVCLINQTOSQL.Controllers
{

    public class MyController : Controller
    {

        public ActionResult Index()
        {
            var userRepositroy = new UserRepository();
            var userList = userRepositroy.GetAll();
            var users = new List<Models.User>();
            MapUser.RegisterMappings();
            if (userList.Any())
            {
                users.AddRange(userList.Select(user => MapUser.ToModel(user)));
            }
            return View(users);
        }

        public ActionResult Details(int id)
        {
            var userRepositroy = new UserRepository();
            var userDetails = userRepositroy.GetById(id);
            MapUser.RegisterMappings();
            var converted = MapUser.ToModel(userDetails);
            return View(converted);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.User userDetails)
        {
            try
            {
                var userRepositroy = new UserRepository();
                MapUser.RegisterMappings();
                var converted = MapUser.ToDataBase(userDetails);
                userRepositroy.Add(converted);
                userRepositroy.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var userRepositroy = new UserRepository();
            var userDetails = userRepositroy.GetById(id);
            var user = new Models.User();
            MapUser.RegisterMappings();
            var converted = MapUser.ToModel(userDetails);
            return View(converted);
        }

        [HttpPost]
        public ActionResult Edit(int id, Tombola.Core.Data.DB.User from)
        {
            TempData["TempData Name"] = "Akhil";
            try
            {
                var userRepositroy = new UserRepository();
                Tombola.Core.Data.DB.User into = userRepositroy.GetById(id);
                into.FirstName = from.FirstName;
                into.LastName = from.LastName;
                into.Address = from.Address;
                into.PhoneNo = from.PhoneNo;
                into.EMail = from.EMail;
                into.Company = from.Company;
                into.Designation = from.Designation;
                userRepositroy.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var userRepositroy = new UserRepository();
            var userDetails = userRepositroy.GetById(id);
            MapUser.RegisterMappings();
            var converted = MapUser.ToModel(userDetails);
            return View(converted);
        }

        [HttpPost]
        public ActionResult Delete(int id, Models.User userDetails)
        {
            try
            {
                var userRepositroy = new UserRepository();
                userRepositroy.DeleteById(id);
                userRepositroy.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
