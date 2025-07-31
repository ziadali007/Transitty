using DomainRoute = Domain.Models.Route;

namespace Transitty.Shared
{
    public class BusResultDto
    {
        public int BusId { get; set; }

        public string BusNumber { get; set; }

        public string BusName { get; set; }

        public int Capacity { get; set; }

        public int RouteId { get; set; }

    }
}
