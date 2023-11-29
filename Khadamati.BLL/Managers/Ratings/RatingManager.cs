using Khadamati.DAL;

namespace Khadamati.BLL.Managers.Ratings
{
    public class RatingManager : IRatingManager
    {
        private readonly IUnitofWork _ratingrepo;

        public RatingManager(IUnitofWork rr)
        {
            _ratingrepo = rr;
        }
        public RatingDto GetRatingByUserAndService(int sid, string uid)
        {
            {
                var rating = _ratingrepo.RatingRepo.GetRatingByUserAndService(sid, uid);
                return new RatingDto
                {
                    Id = rating.Id,
                    UserName = rating.User.UserName,
                    date = rating.date
                };

            }
        }
        public List<RatingDto> GetRatingByServiceId(int id)
        {
            {
                List<Rating>? rating = _ratingrepo.RatingRepo.GetRatingByServiceId(id);
                return rating.Select(r => new RatingDto
                {
                    Id = r.Id,
                    ServiceId = r.ServiceId,
                    UserId = r.UserId,
                    Comment = r.Comment,
                    rating = r.rating,
                    date = r.date,
                    Service = new ServiceRatingDto
                    {
                        ServiceId = r.Service.Id,
                        name = r.Service.Name,
                        rating = r.Service.Rating
                    }
                }).ToList();
            };
        }

        public void UpdateRating(RatingDto rating)
        {
            {
                _ratingrepo.RatingRepo.Update(new Rating
                {
                    Id = rating.Id,
                    ServiceId = rating.ServiceId,
                    UserId = rating.UserId,
                    Comment = rating.Comment,
                    rating = rating.rating,
                    date = (DateTime)rating.date,
                });
            }
        }

        public RatingDto GetRatingById(int id)
        {
            {
                var rating = _ratingrepo.RatingRepo.GetRatingById(id);
                return new RatingDto
                {
                    Id = rating.Id,
                    ServiceId = rating.ServiceId,
                    UserId = rating.UserId,
                    Comment = rating.Comment,
                    rating = rating.rating,
                    date = rating.date,
                    Service = new ServiceRatingDto
                    {
                        ServiceId = rating.Service.Id,
                        name = rating.Service.Name,
                        rating = rating.Service.Rating
                    }
                };
            }
        }

        public void DeleteRating(int id)
        {
            _ratingrepo.RatingRepo.Delete(id);
        }

        public void AddRating(RatingAddDto rating)
        {
            _ratingrepo.RatingRepo.Add(new Rating
            {
                ServiceId = rating.ServiceId,
                UserId = rating.UserId,
                Comment = rating.Comment,
                rating = rating.rating,
                date = DateTime.Now,
            });
        }
    }
}