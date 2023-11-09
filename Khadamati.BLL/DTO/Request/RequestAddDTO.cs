using Khadamati.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khadamati.BLL.DTO.Request;

public class RequestAddDTO
{
    public string? UserId { get; set; }
    public int? ServiceId { get; set; }
    public string? ProviderId { get; set; }
    public string RequestText { get; set; } = string.Empty;
    public string? Status { get; set; }
    public DateTime date { get; set; } = DateTime.Now;

}
