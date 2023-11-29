namespace Khadamati.DAL
{
    public interface IRatingRepo:IGenericRepos<Rating>
    {
        public void Add(Rating rating);
        public void Delete(int id);
        public void Update(Rating rating);
        public List<Rating> GetRatingByServiceId(int id);
        public Rating GetRatingById(int id);
        Rating GetRatingByUserAndService(int sid, string uid);
    }
}
