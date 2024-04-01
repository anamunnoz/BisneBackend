using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Usuarios
{
    public record UpdateUsuarioInput(
        [property: ID(nameof(Usuario_Registrado))] int Id,
        string? nombre,
        string? password,
        string? ImageUrl
    );
    
    
}
