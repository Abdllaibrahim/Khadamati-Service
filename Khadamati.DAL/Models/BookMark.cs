using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khadamati.DAL
{
    [PrimaryKey("ServiceId", "UserId")]
    public class BookMark
    {
        [Range(0,100)]
        public int ServiceId { get; set; }      
        public string UserId { get; set; } 

        public Service? Service { get; set; }
        public SiteUser? User { get; set; }
    }
}
