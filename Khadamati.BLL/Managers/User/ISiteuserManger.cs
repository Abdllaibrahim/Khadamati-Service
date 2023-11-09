using Khadamati.DAL;

namespace Khadamati.BLL
{
    public interface ISiteuserManger
    {
        IUnitofWork Unitofwork { get; }

        List<UserReadDto> GetAll();
        UserReadDto GetUser(string id);
        SiteUser RegisterUser(UserAddDTO userAdd);
        void UpateUserData(string id, UserUpdateDto siteUser);
        public void RemoveUser(string id);
        List<UserReadDto> GetAllUsers();
        List<UserReadDto> GetAllAdmins();
        public UserDetailsDTO GetUserDetails(string id);
        void AddBookmark(string UserID, int serviceID);
        void RemoveBookmark(string id, int serviceID);
    }
}