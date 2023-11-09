using Khadamati.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khadamati.BLL.DTO.Request;

public class RequestUpdateDTO
{
    public int Id { get; set; }
    public string Status { get; set; }
    public string RequestText { get; set; } = string.Empty;
  
}
