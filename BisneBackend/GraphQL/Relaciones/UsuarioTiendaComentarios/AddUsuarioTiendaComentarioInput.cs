using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Relaciones.UsuarioTiendaComentarios
{
    public record AddUsuarioTiendaComentarioInput(


        [property: ID(nameof(Usuario_Registrado))] int usuarioId,
        [property: ID(nameof(Tienda))] int tiendaId,
        string comentario



    );
    
    
}
