using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contactos_crud.Api.Controller
{
    public class contactoController
    {
         [ApiController]
    [Route("api/[controller]")]
    public class ContactoController : ControllerBase
    {
        private readonly IContactoRepository _repository;

        public ContactoController(IContactoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/contacto
        [HttpGet]
        public ActionResult<IEnumerable<Contacto>> GetAll()
        {
            var contactos = _repository.GetAll();
            return Ok(contactos);
        }

        // GET: api/contacto/5
        [HttpGet("{id}")]
        public ActionResult<Contacto> GetById(int id)
        {
            var contacto = _repository.GetById(id);
            if (contacto == null)
                return NotFound(new { message = "Contacto no encontrado" });

            return Ok(contacto);
        }

        // POST: api/contacto
        [HttpPost]
        public ActionResult<Contacto> Create([FromBody] Contacto contacto)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(contacto.Nombre))
                return BadRequest(new { message = "El nombre es obligatorio" });

            if (!new EmailAddressAttribute().IsValid(contacto.Correo))
                return BadRequest(new { message = "Correo inválido" });

            if (string.IsNullOrWhiteSpace(contacto.Telefono))
                return BadRequest(new { message = "El teléfono es obligatorio" });

            _repository.Add(contacto);
            return CreatedAtAction(nameof(GetById), new { id = contacto.Id }, contacto);
        }

        // PUT: api/contacto/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Contacto contacto)
        {
            if (id != contacto.Id)
                return BadRequest(new { message = "El Id no coincide" });

            var existente = _repository.GetById(id);
            if (existente == null)
                return NotFound(new { message = "Contacto no encontrado" });

            _repository.Update(contacto);
            return NoContent();
        }

        // DELETE: api/contacto/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var contacto = _repository.GetById(id);
            if (contacto == null)
                return NotFound(new { message = "Contacto no encontrado" });

            _repository.Delete(id);
            return NoContent();
        }
    }
    }
}