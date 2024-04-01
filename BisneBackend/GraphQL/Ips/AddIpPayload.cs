using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Ips
{
    public class AddIpPayload : IpPayloadBase
    {
        public AddIpPayload(Ip ip) : base(ip) { }
        public AddIpPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
