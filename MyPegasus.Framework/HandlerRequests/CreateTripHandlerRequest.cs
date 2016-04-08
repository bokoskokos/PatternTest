using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPegasus.Framework.HandlerRequests
{
    public class CreateTripHandlerRequest : HandlerRequestBase
    {
        public string Title { get; set; }
        public DateTimeOffset Departure { get; set; }
        public DateTimeOffset Arrival { get; set; }
        public Guid CustomerId { get; set; }
    }
}
