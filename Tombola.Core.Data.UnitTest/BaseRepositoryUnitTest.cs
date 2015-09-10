using System;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tombola.Core.Data;
using Tombola.Core.Data.Repository;
using Tombola.Core.Data.DB;
using Tombola.Core.Data.DB.Interfaces;
using Model = MVCLINQTOSQL.Models;
using Database = Tombola.Core.Data.DB;

namespace Tombola.Core.Data.UnitTest
{
    [TestClass]
    public class BaseRepositoryUnitTest
    {
        [TestInitialize]
        public void TestSetup()
        {
            RegisterMappings();
        }

        [TestMethod]
        public void GetAll()
        {
            using (var userRepository = new UserRepository(new MVCDataContext()))
            {
                var baz = userRepository.GetAll();
                Console.WriteLine(baz);
            }
        }

        [TestMethod]
        public void GetById()
        {
            using (var userRepository = new UserRepository(new MVCDataContext()))
            {
                var baz = userRepository.GetById(1);
                Console.WriteLine(baz.FirstName);
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public static void RegisterOneToOneMap<TypeFrom, TypeTo>()
        {
            AutoMapper.Mapper.CreateMap<TypeFrom, TypeTo>();
            AutoMapper.Mapper.CreateMap<TypeTo, TypeFrom>();
        }

        public static void RegisterMappings()
        {
            RegisterOneToOneMap<Model.User, Database.User>();
        }

        public static class MapUser
        {
            public static Model.User ToModel(Database.User from)
            {
                return AutoMapper.Mapper.Map<Model.User>(from);
            }

            public static Database.User ToDataBase(Model.User from)
            {
                return AutoMapper.Mapper.Map<Database.User>(from);
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        [TestMethod]
        public void Mapper()
        {
            Database.User user = new UserRepository(new MVCDataContext()).GetById(1);
            AutoMapper.Mapper.CreateMap<Model.User, Database.User>();
            Model.User converted = AutoMapper.Mapper.Map<Model.User>(user);
            Console.WriteLine(user.Address);
        }
    }
}
