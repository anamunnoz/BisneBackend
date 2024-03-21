namespace BisneBackend.GraphQL.Usuarios
{
    public record AddUsuarioInput(
        string nombre,
        string correo,
        string password
    );
    
}
