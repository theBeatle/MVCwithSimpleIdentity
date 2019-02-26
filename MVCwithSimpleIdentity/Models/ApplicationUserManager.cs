using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace MVCwithSimpleIdentity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> ops, IOwinContext owinCtx)
        {
            ApplicationContext ctx = owinCtx.Get<ApplicationContext>();
            IUserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(ctx);
            ApplicationUserManager appUserManager = new ApplicationUserManager(userStore);
            return appUserManager;
        }
    }
}