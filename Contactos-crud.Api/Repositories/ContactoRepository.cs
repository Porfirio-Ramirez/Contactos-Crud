using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contactos_crud.Api.Repositories
{
    public class ContactoRepository : IContactoRepository
    {
        private static List<contacto> _contactos = new List<contacto>();

    public IEnumerable<contacto> GetAll() => _contactos;

    public Contacto? GetById(int id) => _contactos.FirstOrDefault(c => c.Id == id);

    public void Add(Contacto contacto)
    {
        contacto.Id = _contactos.Count == 0 ? 1 : _contactos.Max(c => c.Id) + 1;
        _contactos.Add(contacto);
    }

    public void Update(Contacto contacto)
    {
        var existente = GetById(contacto.Id);
        if (existente == null) return;

        existente.Nombre = contacto.Nombre;
        existente.Telefono = contacto.Telefono;
        existente.Correo = contacto.Correo;
    }

    public void Delete(int id)
    {
        var contacto = GetById(id);
        if (contacto != null)
            _contactos.Remove(contacto);
    }
        
    }
}