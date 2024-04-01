using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Relaciones.UsuarioIps
{
    public record AddUsuarioIpInput([property: 
        ID(nameof(Usuario_Registrado))] int usuarioId,
        string ipId
        );

}
