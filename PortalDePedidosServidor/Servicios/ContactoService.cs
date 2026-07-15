using Microsoft.EntityFrameworkCore;
using PortalDePedidosServidor.Models;
using PortalDePedidosShared.ContactosVM;

namespace PortalDePedidosServidor.Servicios
{
    public class ContactoService
    {
        private PortalTestContext _context;

        public ContactoService(PortalTestContext context)
        {
            _context = context;
        }

        public async Task<List<ContactoVM>> GetAllContactos()
        {
            List<ContactoVM> list = new List<ContactoVM>();

            //var contactosDB = await _context.Contactos.ToListAsync();

            //list = contactosDB.Select(x => new ContactoVM
            //{
            //    idContacto = x.IdContacto,
            //    nombreContacto = x.NombreContacto,
            //    mailContacto = x.MailContacto,
            //    observacionContacto = x.ObservacionContacto,
            //    registroAnulado = (x.RegistroAnulado == 1)
            //}).ToList();

            return list;
        }
    }
}
