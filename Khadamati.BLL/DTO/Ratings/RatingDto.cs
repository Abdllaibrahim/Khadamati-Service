namespace Khadamati.BLL
{
    public class RatingDto
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public ServiceRatingDto? Service { get; set; }
        public string? UserName { get; set; }
        public string? UserId { get; set; }
        //public UserRatingDto? User { get; set; }

        public string Comment { get; set; } = string.Empty;
        public float rating { get; set; }
        public DateTime? date { get; set; }


    }
    public class ServiceRatingDto
    {
        public int ServiceId { get; set; }
        public String? name { get; set; }
        public float rating { get; set; }
    }
    //public class UserRatingDto
    //{
    //    public string UserId { get; set; }
    //    public string UserName { get; set; }
    //}
    public class RatingAddDto
    {
        public int ServiceId { get; set; }
        public string? UserId { get; set; }
        public string Comment { get; set; } = string.Empty;
        public float rating { get; set; }
        public DateTime? date { get; set; }
    }
}
