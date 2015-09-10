using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLINQTOSQL.Models
{
    public class User
    {
      //  #region Automated Properties
        public int Id { get; set; }
       // [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Company { get; set; }
        public string Designation { get; set; }
       // #endregion
    }
}