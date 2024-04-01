using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Extensions;
using BisneBackend.AccesoDatos.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BisneBackend.GraphQL.Relaciones.UsuarioIps
{
    [ExtendObjectType("Mutation")]
    public class UsuarioIpMutations
    {
        [UseApplicationDbContext]
        public async Task<AddUsuarioIpPayload> AddUsuarioIpAsync(
            AddUsuarioIpInput input,
            [ScopedService] MyDbContext context)
        {
            var a = await context.UsuarioIps
               .Where(b => b.ipId == input.ipId)
               .Where(c=> c.usuarioRegistradoId == input.usuarioId)
               .ToListAsync();
            
            if(a.Count == 0)
            {
                var usuarioIp = new UsuarioIp
                {
                    usuarioRegistradoId = input.usuarioId,
                    ipId = input.ipId
                };

                context.UsuarioIps.Add(usuarioIp);
                await context.SaveChangesAsync();
                return new AddUsuarioIpPayload(usuarioIp);
            }
            return new AddUsuarioIpPayload(a[0]); 
        }
    }
}
