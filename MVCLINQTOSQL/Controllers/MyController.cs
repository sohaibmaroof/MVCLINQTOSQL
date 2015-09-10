using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVCLINQTOSQL.Mapping;
using Tombola.Core.Data.UnitOfWork;
using Database = Tombola.Core.Data.DB;
namespace MVCLINQTOSQL.Controllers
{

    public class MyController : Controller
    {
        public UnitOfWork unitOfWork=new UnitOfWork();

        public MyController()
        {
            MapUser.RegisterMappings();
        }

        public ActionResult Index()
        {
            var userList = unitOfWork.UseRepository.GetAll();
            var users = new List<Models.User>();
            MapUser.RegisterMappings();
            if (!userList.Any()) return View(users);
            foreach (var user in userList)
                users.Add(MapUser.ToModel(user));
            return View(users);
        }

        public ActionResult Details(int id)
        {
            return View(MapUser.ToModel(unitOfWork.UseRepository.GetById(id)));
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
                unitOfWork.UseRepository.Add(MapUser.ToDataBase(userDetails));
                unitOfWork.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(MapUser.ToModel(unitOfWork.UseRepository.GetById(id)));
        }

        [HttpPost]
        public ActionResult Edit(int id, Database.User from)
        {
            TempData["TempData Name"] = "Akhil";
            try
            {
                Database.User into = unitOfWork.UseRepository.GetById(id);
                into.FirstName = from.FirstName;
                into.LastName = from.LastName;
                into.Address = from.Address;
                into.PhoneNo = from.PhoneNo;
                into.EMail = from.EMail;
                into.Company = from.Company;
                into.Designation = from.Designation;
                unitOfWork.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(MapUser.ToModel(unitOfWork.UseRepository.GetById(id)));
        }

        [HttpPost]
        public ActionResult Delete(int id, Models.User userDetails)
        {
            try
            {
                unitOfWork.UseRepository.DeleteById(id);
                unitOfWork.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
