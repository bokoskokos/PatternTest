using System;

namespace MyPegasus.Framework.HandlerRequests
{
    public class CreateCustomerHandlerRequest : HandlerRequestBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
    }
}
