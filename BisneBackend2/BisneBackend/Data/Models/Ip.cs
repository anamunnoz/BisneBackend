using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisneBackend.Data.Models
{
    [Table("Ip")]
    public class Ip
    {   
        [Key]
        [MaxLength(255)]
        public string? ipId { get; set; }
        
        public ICollection<UsuarioIp> UsuarioIps { get; set; }=new List<UsuarioIp>();
        
    }
}

