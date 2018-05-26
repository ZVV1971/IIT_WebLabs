using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using DAL_ZVV.Entities;

namespace ZVV_Web_Lab_1.App_Start
{
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(RoleStore<IdentityRole> store) : base(store)
        { }
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,
                IOwinContext context)
        {
           return new ApplicationRoleManager(new
           RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
        }
    }
}