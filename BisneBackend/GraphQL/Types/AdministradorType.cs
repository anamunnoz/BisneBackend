using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Types
{
    public class AdministradorType : ObjectType<AdministradordeTienda>
    {
        protected override void Configure(IObjectTypeDescriptor<AdministradordeTienda> descriptor)
        {
           descriptor
                .Field(t => t.Id)
                .ID("Usuario_Registrado");
            
        }
    }
}