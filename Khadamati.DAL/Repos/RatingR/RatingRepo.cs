using Microsoft.EntityFrameworkCore;

namespace Khadamati.DAL
{
    public class RatingRepo :GenericRepo<Rating>, IRatingRepo
    {
        private readonly KhadamatiContext _db;

        public RatingRepo(KhadamatiContext db):base(db)
        {
            _db = db;
        }
        public void Add(Rating rating)
        {
            _db.Ratings.Add(rating);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var rating = _db.Ratings.Find(id);
            _db.Ratings.Remove(rating);
            _db.SaveChanges();
        }
        public List<Rating> GetRatingByServiceId(int id)
        {
            var rating = _db.Ratings.Include(d => d.Service).Where(r => r.ServiceId == id).ToList();
            return rating;

        }
        public Rating GetRatingById(int id)
        {
            var rating = _db.Ratings.Include(d => d.Service).Where(r => r.Id == id).FirstOrDefault();
            return rating;
        }
        public void Update(Rating rating)
        {
            _db.Ratings.Update(rating);
            _db.SaveChanges();
        }

        public Rating GetRatingByUserAndService(int sid, string uid)
        {
            var rating = _db.Ratings.Where(r => r.ServiceId == sid && r.UserId == uid)
            .Include(r => r.User).FirstOrDefault();
            return rating;
        }
    }
}
