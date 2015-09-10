using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Tombola.Core.Data.Repository;
using MVCLINQTOSQL.Mapping;
using Database = Tombola.Core.Data.DB;
namespace MVCLINQTOSQL.Controllers
{

    public class MyController : Controller
    {
        private readonly UserRepository _userRepository;
        
        public MyController()
        {
            this._userRepository=new UserRepository(new Database.MVCDataContext());
            MapUser.RegisterMappings();
        }
        public ActionResult Index()
        {
            var userList = _userRepository.GetAll();
            var users = new List<Models.User>();
            MapUser.RegisterMappings();
            if (!userList.Any()) return View(users);
            foreach (var user in userList)
                users.Add(MapUser.ToModel(user));
            return View(users);
        }

        public ActionResult Details(int id)
        {
          return View(MapUser.ToModel(_userRepository.GetById(id)));
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
               _userRepository.Add(MapUser.ToDataBase(userDetails));
                _userRepository.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(MapUser.ToModel(_userRepository.GetById(id)));
        }

        [HttpPost]
        public ActionResult Edit(int id, Database.User from)
        {
            TempData["TempData Name"] = "Akhil";
            try
            {
                Database.User into = _userRepository.GetById(id);
                into.FirstName = from.FirstName;
                into.LastName = from.LastName;
                into.Address = from.Address;
                into.PhoneNo = from.PhoneNo;
                into.EMail = from.EMail;
                into.Company = from.Company;
                into.Designation = from.Designation;
                _userRepository.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(MapUser.ToModel(_userRepository.GetById(id)));
        }

        [HttpPost]
        public ActionResult Delete(int id, Models.User userDetails)
        {
            try
            {
                _userRepository.DeleteById(id);
                _userRepository.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
