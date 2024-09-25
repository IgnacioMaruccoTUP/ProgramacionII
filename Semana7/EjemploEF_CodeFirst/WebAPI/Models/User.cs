using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("Usuarios")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Clave { get; set; }
        public bool Active { get; set; }
        [ForeignKey("Rol")]
        public int IdRol { get; set; }
        public Rol Rol { get; set; }
    }
}
