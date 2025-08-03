using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class RouteStopDto
    {
       
         public int RouteId { get; set; }      
         public int StopId { get; set; }
         public string StopName { get; set; } = string.Empty;
         public string Location { get; set; } = string.Empty;
         public int StopOrder { get; set; }
       

    }
}
