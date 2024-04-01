using Microsoft.EntityFrameworkCore;
using BisneBackend.AccesoDatos.Data;
using BisneBackend.GraphQL.DataLoader;
using BisneBackend.GraphQL.Categorias;
using BisneBackend.GraphQL.Types;
using BisneBackend.GraphQL.Tiendas;
using BisneBackend.GraphQL.Ofertas;
using BisneBackend.GraphQL.Usuarios;
using BisneBackend.GraphQL.Facturas;
using BisneBackend.GraphQL.Relaciones.FacturaOfertas;
using BisneBackend.GraphQL.Relaciones.UsuarioTiendaFavs;
using BisneBackend.GraphQL.Relaciones.UsuarioTiendaComentarios;
using BisneBackend.GraphQL.Relaciones.UsuarioTiendaValoraciones;
using BisneBackend.GraphQL.Relaciones.UsuarioOfertaComentarios;
using BisneBackend.GraphQL.Relaciones.UsuarioOfertaFavs;
using BisneBackend.GraphQL.Relaciones.UsuarioOfertaValoraciones;
using BisneBackend.GraphQL.Etiquetas;
using BisneBackend.GraphQL.Ips;
using BisneBackend.GraphQL.Relaciones.UsuarioIps;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddGraphQLServer()
    .AddQueryableCursorPagingProvider()
    .AddQueryType(d => d.Name("Query"))
        .AddTypeExtension<CategoriaQueries>()
        .AddTypeExtension<TiendaQueries>()
        .AddTypeExtension<OfertaQueries>()
        .AddTypeExtension<UsuarioQueries>()
        .AddTypeExtension<FacturaQueries>()
        .AddTypeExtension<EtiquetaQueries>()
    .AddMutationType(d => d.Name("Mutation"))
        .AddTypeExtension<TiendaMutations>()
        .AddTypeExtension<UsuarioTiendaFavMutations>()
        .AddTypeExtension<UsuarioOfertaFavMutations>()
        .AddTypeExtension<UsuarioTiendaValoracionMutations>()
        .AddTypeExtension<UsuarioOfertaValoracionMutations>()
        .AddTypeExtension<UsuarioTiendaComentarioMutations>()
        .AddTypeExtension<UsuarioOfertaComentarioMutations>()
        .AddTypeExtension<FacturaOfertaMutations>()
        .AddTypeExtension<CategoriaMutations>()
        .AddTypeExtension<FacturaMutations>()
        .AddTypeExtension<OfertaMutations>()
        .AddTypeExtension<UsuarioMutations>()
        .AddTypeExtension<EtiquetaMutations>()
        .AddTypeExtension<IpMutations>()
        .AddTypeExtension<UsuarioIpMutations>()
    .AddType<CategoriaType>()
    .AddType<AdministradorType>()
    .AddType<FacturaType>()
    .AddType<OfertaType>()
    .AddType<TiendaType>()
    .AddType<EtiquetaType>()
    .AddType<UsuarioTiendaComentarioType>()
    .AddType<UsuarioType>()
    .AddType<UsuarioOfertaComentarioType>()
    .AddDataLoader<CategoriaByIdDataLoader>()
    .AddDataLoader<OfertaByIdDataLoader>()
    .EnableRelaySupport();
    

var connectionString = builder.Configuration.GetConnectionString("PosgreSQLConnection");
builder.Services.AddPooledDbContextFactory<MyDbContext>(options =>
options.UseNpgsql(connectionString,b => b.MigrationsAssembly("BisneBackend")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();

