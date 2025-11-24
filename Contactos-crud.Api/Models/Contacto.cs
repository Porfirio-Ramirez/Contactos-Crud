using System.ComponentModel.DataAnnotations;

namespace Contactos_crud.Api.Models
{
    public class Contacto
    {

        public int Id { get; set; }

       [Required(ErrorMessage = "El nombre es obligatorio")]
       public string Nombre {get; set;}
       [Required(ErrorMessage = "El teléfono es obligatorio")]
       public string Telefono {get; set;}
       [Required(ErrorMessage = "El correo es obligatorio")]
       public string Correo {get; set;}
      
    }
}