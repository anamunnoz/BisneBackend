using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BisneBackend.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    padreId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categoria_Categoria_padreId",
                        column: x => x.padreId,
                        principalTable: "Categoria",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ip",
                columns: table => new
                {
                    ipId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ip", x => x.ipId);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRegistrado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    correo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRegistrado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrador_UsuarioRegistrado_Id",
                        column: x => x.Id,
                        principalTable: "UsuarioRegistrado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    direccion_envio = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    usuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factura_UsuarioRegistrado_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "UsuarioRegistrado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioIps",
                columns: table => new
                {
                    usuarioRegistradoId = table.Column<int>(type: "integer", nullable: false),
                    ipId = table.Column<string>(type: "character varying(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioIps", x => new { x.usuarioRegistradoId, x.ipId });
                    table.ForeignKey(
                        name: "FK_UsuarioIps_Ip_ipId",
                        column: x => x.ipId,
                        principalTable: "Ip",
                        principalColumn: "ipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioIps_UsuarioRegistrado_usuarioRegistradoId",
                        column: x => x.usuarioRegistradoId,
                        principalTable: "UsuarioRegistrado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tienda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    horario = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    numeroWhatsapp = table.Column<int>(type: "integer", nullable: true),
                    numeroTelefono = table.Column<int>(type: "integer", nullable: true),
                    usuarioTelegram = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    linkFacebook = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    linkInstagram = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    linkExtra = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ImageURL = table.Column<string>(type: "text", nullable: true),
                    administradorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tienda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tienda_Administrador_administradorId",
                        column: x => x.administradorId,
                        principalTable: "Administrador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    precio = table.Column<int>(type: "integer", nullable: false),
                    cantidad = table.Column<int>(type: "integer", nullable: false),
                    descuento = table.Column<int>(type: "integer", nullable: true),
                    tiendaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oferta_Tienda_tiendaId",
                        column: x => x.tiendaId,
                        principalTable: "Tienda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioTiendaComentarios",
                columns: table => new
                {
                    usuarioId = table.Column<int>(type: "integer", nullable: false),
                    tiendaId = table.Column<int>(type: "integer", nullable: false),
                    comentario = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioTiendaComentarios", x => new { x.usuarioId, x.tiendaId });
                    table.ForeignKey(
                        name: "FK_UsuarioTiendaComentarios_Tienda_tiendaId",
                        column: x => x.tiendaId,
                        principalTable: "Tienda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioTiendaComentarios_UsuarioRegistrado_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "UsuarioRegistrado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioTiendaFavs",
                columns: table => new
                {
                    usuarioId = table.Column<int>(type: "integer", nullable: false),
                    tiendaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioTiendaFavs", x => new { x.usuarioId, x.tiendaId });
                    table.ForeignKey(
                        name: "FK_UsuarioTiendaFavs_Tienda_tiendaId",
                        column: x => x.tiendaId,
                        principalTable: "Tienda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioTiendaFavs_UsuarioRegistrado_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "UsuarioRegistrado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioTiendaValoraciones",
                columns: table => new
                {
                    usuarioId = table.Column<int>(type: "integer", nullable: false),
                    tiendaId = table.Column<int>(type: "integer", nullable: false),
                    valoracion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioTiendaValoraciones", x => new { x.usuarioId, x.tiendaId });
                    table.ForeignKey(
                        name: "FK_UsuarioTiendaValoraciones_Tienda_tiendaId",
                        column: x => x.tiendaId,
                        principalTable: "Tienda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioTiendaValoraciones_UsuarioRegistrado_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "UsuarioRegistrado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturaOfertas",
                columns: table => new
                {
                    ofertaId = table.Column<int>(type: "integer", nullable: false),
                    facturaId = table.Column<int>(type: "integer", nullable: false),
                    cantidad = table.Column<double>(type: "double precision", nullable: false),
                    monto_total = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaOfertas", x => new { x.facturaId, x.ofertaId });
                    table.ForeignKey(
                        name: "FK_FacturaOfertas_Factura_facturaId",
                        column: x => x.facturaId,
                        principalTable: "Factura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaOfertas_Oferta_ofertaId",
                        column: x => x.ofertaId,
                        principalTable: "Oferta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfertaCategorias",
                columns: table => new
                {
                    ofertaId = table.Column<int>(type: "integer", nullable: false),
                    categoriaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaCategorias", x => new { x.ofertaId, x.categoriaId });
                    table.ForeignKey(
                        name: "FK_OfertaCategorias_Categoria_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfertaCategorias_Oferta_ofertaId",
                        column: x => x.ofertaId,
                        principalTable: "Oferta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prodcuto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    marca = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    volumen = table.Column<double>(type: "double precision", nullable: false),
                    peso = table.Column<double>(type: "double precision", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodcuto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prodcuto_Oferta_Id",
                        column: x => x.Id,
                        principalTable: "Oferta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    horario = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicio_Oferta_Id",
                        column: x => x.Id,
                        principalTable: "Oferta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioOfertaComentarios",
                columns: table => new
                {
                    usuarioId = table.Column<int>(type: "integer", nullable: false),
                    ofertaId = table.Column<int>(type: "integer", nullable: false),
                    comentario = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioOfertaComentarios", x => new { x.usuarioId, x.ofertaId });
                    table.ForeignKey(
                        name: "FK_UsuarioOfertaComentarios_Oferta_ofertaId",
                        column: x => x.ofertaId,
                        principalTable: "Oferta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioOfertaComentarios_UsuarioRegistrado_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "UsuarioRegistrado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioOfertaValoraciones",
                columns: table => new
                {
                    usuarioId = table.Column<int>(type: "integer", nullable: false),
                    ofertaId = table.Column<int>(type: "integer", nullable: false),
                    valoracion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioOfertaValoraciones", x => new { x.usuarioId, x.ofertaId });
                    table.ForeignKey(
                        name: "FK_UsuarioOfertaValoraciones_Oferta_ofertaId",
                        column: x => x.ofertaId,
                        principalTable: "Oferta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioOfertaValoraciones_UsuarioRegistrado_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "UsuarioRegistrado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_padreId",
                table: "Categoria",
                column: "padreId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_usuarioId",
                table: "Factura",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaOfertas_ofertaId",
                table: "FacturaOfertas",
                column: "ofertaId");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_tiendaId",
                table: "Oferta",
                column: "tiendaId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaCategorias_categoriaId",
                table: "OfertaCategorias",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tienda_administradorId",
                table: "Tienda",
                column: "administradorId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioIps_ipId",
                table: "UsuarioIps",
                column: "ipId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioOfertaComentarios_ofertaId",
                table: "UsuarioOfertaComentarios",
                column: "ofertaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioOfertaValoraciones_ofertaId",
                table: "UsuarioOfertaValoraciones",
                column: "ofertaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTiendaComentarios_tiendaId",
                table: "UsuarioTiendaComentarios",
                column: "tiendaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTiendaFavs_tiendaId",
                table: "UsuarioTiendaFavs",
                column: "tiendaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTiendaValoraciones_tiendaId",
                table: "UsuarioTiendaValoraciones",
                column: "tiendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacturaOfertas");

            migrationBuilder.DropTable(
                name: "OfertaCategorias");

            migrationBuilder.DropTable(
                name: "Prodcuto");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "UsuarioIps");

            migrationBuilder.DropTable(
                name: "UsuarioOfertaComentarios");

            migrationBuilder.DropTable(
                name: "UsuarioOfertaValoraciones");

            migrationBuilder.DropTable(
                name: "UsuarioTiendaComentarios");

            migrationBuilder.DropTable(
                name: "UsuarioTiendaFavs");

            migrationBuilder.DropTable(
                name: "UsuarioTiendaValoraciones");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Ip");

            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "Tienda");

            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "UsuarioRegistrado");
        }
    }
}
