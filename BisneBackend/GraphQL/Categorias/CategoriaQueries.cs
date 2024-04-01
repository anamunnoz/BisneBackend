using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Extensions;
using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;


namespace BisneBackend.GraphQL.Categorias
{
    [ExtendObjectType("Query")]
    public class CategoriaQueries
    {
        //Obtener todas las categorias
        [UseApplicationDbContext]
        public Task<List<Categoria>> GetCategorias([ScopedService] MyDbContext context) =>
            context.Categorias.ToListAsync();


        public Task<Categoria> GetCategoriaAsync(
             [ID(nameof(Categoria))] int id,
             CategoriaByIdDataLoader dataLoader,
             CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);

        [UseApplicationDbContext]
        public async Task<IReadOnlyList<Oferta>> GetCategoriaOfertasAsync(
             [ScopedService] MyDbContext context,
             [ID(nameof(Categoria))] int? id, 
             double precio_min = 0, double precio_max = double.MaxValue, string? nombre="")
        {
            
            var ofertaIds = await context.Ofertas
                .Where(o => o.nombre.ToLower().Contains(nombre.ToLower()))
                .Where(m=>m.precio>=precio_min)
                .Where(mx=>mx.precio<=precio_max).ToListAsync();
            if(id != null)
            {
                var ofer= ofertaIds.Where(t => t.categoriaId == id)
                    .ToList();
                return ofer;
            }
            return ofertaIds;
            
        }

        [UseApplicationDbContext]
        public async Task<List<Tienda>> GetCategoriaTiendasAsync(
            [ID(nameof(Categoria))] int? id,
            [ScopedService] MyDbContext context,
            CategoriaByIdDataLoader dataLoader,
            CancellationToken cancellationToken,
            string provincia = "", string municipio = "", string? nombre="")
        {
            var tiendas = await context.Tiendas
                .Where(t => t.nombre.ToLower().Contains(nombre.ToLower()))
                .Where(a=>a.provincia.Contains(provincia))
                .Where(b=>b.municipio.Contains(municipio))
                .ToListAsync();
            if (id == null) return tiendas;

           
            List<Tienda>  tienda_categoria = new List<Tienda>();
            foreach(var tienda in tiendas)
            {
                int categoriaMasFrecuente=-1;
                var ofertas = await context.Ofertas
                .Where(o => o.tiendaId == tienda.Id).ToListAsync();
                if (ofertas.Count != 0)
                {
                    categoriaMasFrecuente = ofertas
                    .GroupBy(o => o.categoriaId)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .FirstOrDefault();   
                }
                if (categoriaMasFrecuente != -1)
                {
                    var categoria = await dataLoader.LoadAsync(categoriaMasFrecuente, cancellationToken);
                    if (categoria.Id == id)
                    {
                        tienda_categoria.Add(tienda);
                    }
                }
            }
            return tienda_categoria;
        }
    }
}
