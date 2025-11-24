namespace Contactos_crud.Api.Repositories
{
    public interface IContactoRepository
    {
        IEnumerable<Contacto> GetAll();
        Contacto? GetById(int id);
        void Add(Contacto contacto);
        void Update(Contacto contacto);
        void Delete(int id);
    }
}