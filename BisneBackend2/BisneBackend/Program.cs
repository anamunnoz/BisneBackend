using BisneBackend.Data;
using BisneBackend.GraphQl;
using BisneBackend.GraphQL;
using BisneBackend.GraphQL.DataLoader;
using BisneBackend.GraphQL.Types;
using BisneBackend.GraphQL.Categorias;
using Microsoft.EntityFrameworkCore;
using BisneBackend.GraphQL.Tiendas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
        .AddTypeExtension<CategoriaQueries>()
        .AddTypeExtension<TiendaQueries>()
    .AddMutationType(d => d.Name("Mutation"))
        .AddTypeExtension<TiendaMutations>()
        .AddTypeExtension<CategoriaMutations>()
    .AddType<CategoriaType>()
    .AddType<AdministradorType>()
    .AddType<FacturaType>()
    .AddType<OfertaType>()
    .AddType<TiendaType>()
    .AddType<UsuarioType>()
    .AddDataLoader<CategoriaByIdDataLoader>()
    .AddDataLoader<OfertaByIdDataLoader>();
    //.EnableRelaySupport();
    


builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PosgreSQLConnection");
builder.Services.AddPooledDbContextFactory<MyDbContext>(options =>
options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();


app.Run();

