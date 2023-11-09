using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Khadamati.DAL
{
    public class UserRepo : GenericRepo<SiteUser>, IUserRepo
    {
        public UserManager<SiteUser> UserManager { get; set; }
        public KhadamatiContext Context { get; set; }
        public UserRepo(KhadamatiContext context) : base(context)
        {
            Context = context;
        }
        public List<SiteUser> GetAllUsers()
        {
            List<string>ids = Context.UserClaims.Where(i => i.ClaimValue == "User").Select(i =>i.UserId).ToList();
            List<SiteUser> users = new List<SiteUser>();
            foreach(string id in ids )
            {
                users.Add(GetUserById(id));
            }
            return users;
        }
        public List<SiteUser> GetAllAdmins()
        {
            List<string> ids = Context.UserClaims.Where(i => i.ClaimValue == "Admin").Select(i => i.UserId).ToList();
            List<SiteUser> users = new List<SiteUser>();
            foreach (string id in ids)
            {
                users.Add(GetUserById(id));
            }
            return users;
        }

        public SiteUser GetUserById(string id)
        {
            return Context.Set<SiteUser>().Find(id);
        }
        public SiteUser GeUserDetailsbyId(string id)
        {
            return Context.Set<SiteUser>()
                .Include(i=>i.Services).ThenInclude(s=>s.Ratings)
                .Include(i => i.Services).ThenInclude(s => s.Requests)
                .Include(i=>i.Bookmarks).ThenInclude(b=>b.Service)
                .Include(i=>i.UserRequests).ThenInclude(b => b.Service)
                .Include(i=>i.Notifications)
                .Include(i=>i.Ratings)
                .FirstOrDefault(i=>i.Id==id)!;
        }
        public SiteUser UserBookMarks(string id)
        {
            return Context.Set<SiteUser>()
                .Include(i => i.Bookmarks).ThenInclude(b => b.Service)
                .FirstOrDefault(i => i.Id == id)!;
        }

    }
}
