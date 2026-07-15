using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortalDePedidosModel;
using PortalDePedidosServidor.Models;
using PortalDePedidosServidor.ModelsDataWhereHouse;
using PortalDePedidosShared.AuditoriasVM;

namespace PortalDePedidosServidor.Servicios
{
    public class AuditoriasService
    {
        private PortalTestContext _context;

        public AuditoriasService(PortalTestContext context)
        {
            _context = context;
        }

        public async Task<List<AuditoriasVM>> GetAllAuditorias()
        {
            List<AuditoriasVM> list = new List<AuditoriasVM>();

            var auditoriasDB = await _context.Auditorias.ToListAsync();

            list = auditoriasDB.Select(x => new AuditoriasVM
            {
                id = x.Id,
                idUsuario = (int)x.IdUsuario,
                idOperacion = (int)x.IdOperacion,
                timestamps = (DateTime)x.Timestamps
            }).ToList();
            return list;
        }

        public async Task GuardarNuevaAuditoria(AuditoriasVM auditoriasVM)
        {
            var auditoriaDB = new Auditoria();
            auditoriaDB.IdUsuario = (short)auditoriasVM.idUsuario;
            auditoriaDB.IdOperacion = auditoriasVM.idOperacion;
            auditoriaDB.Timestamps = DateTime.Now;

            _context.Entry(auditoriaDB).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

    }
}
