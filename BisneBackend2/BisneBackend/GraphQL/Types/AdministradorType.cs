using BisneBackend.Data;
using BisneBackend.Data.Extensions;
using BisneBackend.Data.Models;
using BisneBackend.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;


namespace BisneBackend.GraphQL.Types
{
    public class AdministradorType : ObjectType<AdministradordeTienda>
    {
        protected override void Configure(IObjectTypeDescriptor<AdministradordeTienda> descriptor)
        {
           /* descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<AdministradorByIdDataLoader>()
                .LoadAsync(id, ctx.RequestAborted));*/
            

        }

        private class AdministradorResolvers
        {
            
        }
    }
}