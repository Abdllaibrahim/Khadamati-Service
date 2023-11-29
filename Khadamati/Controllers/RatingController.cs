using Khadamati.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Khadamati.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingManager _ratingRepo;

        public RatingController(IRatingManager ratingRepo)
        {
            _ratingRepo = ratingRepo;
        }
        [HttpGet]
        public ActionResult<RatingDto> GetRatingByUserAndService(int sid, string uid)
        {
            return _ratingRepo.GetRatingByUserAndService(sid, uid);
        }
        [HttpGet("id")]
        public ActionResult<RatingDto> GetRatingById(int id)
        {
            return _ratingRepo.GetRatingById(id);
        }

        [HttpGet("Service/{id}")]
        public ActionResult<List<RatingDto>> GetRatingByServiceId(int id)
        {
            return _ratingRepo.GetRatingByServiceId(id);
        }
        [HttpPut]
        public ActionResult UpdateRating(RatingDto rating)
        {
            _ratingRepo.UpdateRating(rating);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRating(int id)
        {
            _ratingRepo.DeleteRating(id);
            return Ok();
        }
        [HttpPost]
        public ActionResult AddRating(RatingAddDto rating)
        {
            _ratingRepo.AddRating(rating);
            return Ok();
        }        
    }
}
