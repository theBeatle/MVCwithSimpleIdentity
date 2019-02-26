using Microsoft.AspNet.Identity.EntityFramework;
using MVCwithSimpleIdentity.Models.DbModels;
using System;

namespace MVCwithSimpleIdentity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }
        public virtual Ocupation Ocupation { get; set; }

    }
}