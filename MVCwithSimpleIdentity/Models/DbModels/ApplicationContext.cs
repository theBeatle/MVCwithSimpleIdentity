using Microsoft.AspNet.Identity.EntityFramework;
using MVCwithSimpleIdentity.Models.DbModels;
using System.Data.Entity;

namespace MVCwithSimpleIdentity
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("MyConnectionString") {}

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        public virtual DbSet<Ocupation> Ocupations { get; set; }

    }
}