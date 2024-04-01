using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;
namespace BisneBackend.GraphQL.Ips
{
    public class IpPayloadBase : Payload
    {
        protected IpPayloadBase(Ip ip)
        {
            Ip = ip;
        }

        protected IpPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Ip? Ip { get; }
    }
}

