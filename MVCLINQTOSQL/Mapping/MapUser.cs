using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model = MVCLINQTOSQL.Models;
using Database = Tombola.Core.Data.DB;

namespace MVCLINQTOSQL.Mapping
{
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
        public static void RegisterOneToOneMap<TypeFrom,TypeTo>()
        {
            AutoMapper.Mapper.CreateMap<TypeFrom, TypeTo>();
            AutoMapper.Mapper.CreateMap<TypeTo, TypeFrom>();
        }
        public static void RegisterMappings()
        {
            RegisterOneToOneMap<Model.User, Database.User>();
        }
    }
}