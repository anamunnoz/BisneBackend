namespace BisneBackend.GraphQL.Inputs
{
    public record AddOfertaInput(string nombre, string descripcion, int precio, int cantidad,int tiendaID, int? descuento);
}
