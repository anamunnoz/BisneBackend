using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Extensions;
using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Usuarios
{
    [ExtendObjectType("Mutation")]
    public class UsuarioMutations
    {

        [UseApplicationDbContext]
        public async Task<AddUsuarioPayload> AddUsuarioAsync(
           AddUsuarioInput input,
           [ScopedService] MyDbContext context,
           CancellationToken cancellationToken)
        {
            var usuario = new Usuario_Registrado
            {
                nombre = input.nombre,
                correo = input.correo,
                password = input.password,
                ImageURL = ""
                
            };

            context.Usuarios_Registrados.Add(usuario);
            await context.SaveChangesAsync(cancellationToken);

            return new AddUsuarioPayload(usuario);
        }

        [UseApplicationDbContext]
        public async Task<UpdateUsuarioPayload> UpdateUsuarioAsync(
            UpdateUsuarioInput input,
            [ScopedService] MyDbContext context,
            CancellationToken cancellationToken)
        {
            Usuario_Registrado usuario = await context.Usuarios_Registrados.FindAsync(input.Id);
            
            if(input.nombre != null) usuario.nombre = input.nombre;
            if (input.password != null) usuario.password = input.password;
            if (input.ImageUrl != null) usuario.ImageURL = input.ImageUrl;

            await context.SaveChangesAsync(cancellationToken);

            return new UpdateUsuarioPayload(usuario);
        }

    }
}
