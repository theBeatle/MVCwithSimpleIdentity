using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCwithSimpleIdentity.Models.DbModels
{
    public class Ocupation
    {
        public Ocupation()
        {
            ApplicationUsers = new HashSet<ApplicationUser>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //navigation property
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}