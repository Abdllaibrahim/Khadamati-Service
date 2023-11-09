using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khadamati.DAL
{
    [PrimaryKey("Id")]
    public class Rating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public string? UserId { get; set; }
        public SiteUser? User { get; set; }

        public string Comment { get; set; }=string.Empty;
        public float rating { get; set; }
        public DateTime date { get; set; }

    }
}
