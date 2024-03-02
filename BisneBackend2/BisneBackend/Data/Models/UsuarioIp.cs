using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisneBackend.Data.Models
{
    public class UsuarioIp
    {
        [Required]
        public int usuarioRegistradoId { get; set; }

        [ForeignKey("usuarioRegistradoId")]
        public Usuario_Registrado? usuarioRegistrado { get; set; }


        [Required]
        public string? ipId { get; set; }

        [ForeignKey("ipId")]
        public Ip? ip { get; set; }


     

    }
}
