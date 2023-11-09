using Khadamati.DAL;
using Microsoft.AspNetCore.Identity;

namespace Khadamati.DAL
{
    public interface IUserRepo : IGenericRepos<SiteUser>
    {
        UserManager<SiteUser> UserManager { get; set; }

        List<SiteUser> GetAllAdmins();
        List<SiteUser> GetAllUsers();
        SiteUser GetUserById(string id);
        SiteUser GeUserDetailsbyId(string id);
    }
}