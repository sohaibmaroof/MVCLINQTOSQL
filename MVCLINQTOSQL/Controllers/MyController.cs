using AutoMapper;
using MVCLINQTOSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tombola.Core.Data.Repository;
using Tombola.Core.Data.DB;

namespace MVCLINQTOSQL.Controllers
{

    public class MyController : Controller
    {
        
        public ActionResult Index()
        {
            var userRepositroy = new UserRepository();
            var userList = userRepositroy.GetAll();
            var users = new List<Models.User>();
            if (userList.Any())
            {
                foreach (var user in userList)
                    users.Add(new Models.User()
                    {
                        Id = user.Id,
                        Address = user.Address,
                        Company = user.Company,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Designation = user.Designation,
                        EMail = user.EMail,
                        PhoneNo = user.PhoneNo
                    });
            }
            ViewBag.FirstName = "My First Name";
            ViewData["FirstName"] = "My First Name";
            if (TempData.Any())
            {
                var tempData = TempData["TempData Name"];
            }
            return View(users);
        }

       public ActionResult Details(int id)
        {
            var userRepositroy = new UserRepository();
            var userDetails = userRepositroy.GetById(id);
            Mapper.CreateMap<Tombola.Core.Data.DB.User, Models.User>();
            var converted = Mapper.Map<Models.User>(userDetails);
            //var user = new Models.User();
            //user.Id = userDetails.Id;
            //    user.FirstName = userDetails.FirstName;
            //    user.LastName = userDetails.LastName;
            //    user.Address = userDetails.Address;
            //    user.PhoneNo = userDetails.PhoneNo;
            //    user.EMail = userDetails.EMail;
            //    user.Company = userDetails.Company;
            //    user.Designation = userDetails.Designation;
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
                var user = new Tombola.Core.Data.DB.User();
                Mapper.CreateMap<Models.User, Tombola.Core.Data.DB.User>();
                var converted = Mapper.Map<Tombola.Core.Data.DB.User>(user);
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
            Mapper.CreateMap<Tombola.Core.Data.DB.User, Models.User>();
            var converted = Mapper.Map<Models.User>(userDetails);
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
               //Mapper.CreateMap<Models.User, Tombola.Core.Data.DB.User>();
                AutoMapper.Mapper.Map(from, into);
              //Tombola.Core.Data.DB.User converted = Mapper.Map<Tombola.Core.Data.DB.User>(from);
                into.FirstName = from.FirstName;
              //  into.FirstName = converted.FirstName;
               //into.FirstName = converted.FirstName;
               //into.LastName = converted.LastName;
               //into.Address = converted.Address;
               //into.PhoneNo = converted.PhoneNo;
               //into.EMail = converted.EMail;
               //into.Company = converted.Company;
               //into.Designation = converted.Designation;
               // Mapper.Map(from, into);
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
            var user = new Models.User();
            Mapper.CreateMap<Tombola.Core.Data.DB.User, Models.User>();
            var converted = Mapper.Map<Models.User>(userDetails);
            //user.FirstName = userDetails.FirstName;
            //user.LastName = userDetails.LastName;
            //user.Address = userDetails.Address;
            //user.PhoneNo = userDetails.PhoneNo;
            //user.EMail = userDetails.EMail;
            //user.Company = userDetails.Company;
            //user.Designation = userDetails.Designation;

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
