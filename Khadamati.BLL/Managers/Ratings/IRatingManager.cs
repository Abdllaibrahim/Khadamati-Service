namespace Khadamati.BLL
{
    public interface IRatingManager
    {
        void AddRating(RatingAddDto rating);
        void DeleteRating(int id);
        void UpdateRating(RatingDto rating);
        List<RatingDto> GetRatingByServiceId(int id);
        RatingDto GetRatingById(int id);
        RatingDto GetRatingByUserAndService(int sid, string uid);
    }
}
