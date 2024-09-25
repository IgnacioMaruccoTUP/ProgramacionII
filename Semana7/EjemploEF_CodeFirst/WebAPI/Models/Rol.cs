using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Rol
    {
        [Key]
        //[Column("id_rol")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        //public ICollection<User> Usuarios = new List<User>();
    }
}
