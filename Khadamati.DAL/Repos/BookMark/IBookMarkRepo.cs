namespace Khadamati.DAL
{
    public interface IBookMarkRepo : IGenericRepos<BookMark>
    {
        BookMark returnBookmark(string uid, int sid);
    }
}
