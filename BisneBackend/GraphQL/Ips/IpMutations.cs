using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.AccesoDatos.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BisneBackend.GraphQL.Ips
{
    [ExtendObjectType("Mutation")]
    public class IpMutations
    {
        [UseApplicationDbContext]
        public async Task<AddIpPayload> AddIpAsync(
            AddIpInput input,
            [ScopedService] MyDbContext context)
        {
            var a = await context.Ips
                .Where(b => b.ipId == input.ipId).ToListAsync();
            if(a.Count != 0)
            {
                var ip = new Ip
                {
                    ipId = input.ipId
                };
                context.Ips.Add(ip);
                await context.SaveChangesAsync();

                return new AddIpPayload(ip);
            }
            return new AddIpPayload(a[0]);

            
        }
    }
}