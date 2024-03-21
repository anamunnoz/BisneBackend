using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisneBackend.Data.Models
{
    [Table("Administrador")]
    public class AdministradordeTienda
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public Usuario_Registrado? datos { get; set; }

    }
}
