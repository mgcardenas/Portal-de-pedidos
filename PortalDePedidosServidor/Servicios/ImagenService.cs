using Microsoft.EntityFrameworkCore;
using PortalDePedidosServidor.Models;
using PortalDePedidosShared.ArticulosVM;

namespace PortalDePedidosServidor.Servicios
{
    public class ImagenService
    {
        private PortalTestContext _context;
        public ImagenService(PortalTestContext context)
        {
            _context = context;
        }
        public async Task<ImagenVM> GetImagen(string idArticulo)
        {
            ImagenVM imagenVM = new();
            var imagenDb = await _context.Imagenes.Where(x => x.IdArticulo == idArticulo).FirstOrDefaultAsync();
            if (imagenDb != null)
            {
                imagenVM.IdImagen = imagenDb.Id;
                imagenVM.Codigo = imagenDb.Codigo;
                imagenVM.IdArticulo = imagenDb.IdArticulo;

                return imagenVM;
            }
            else
            {
                imagenVM.Codigo = "";
                imagenVM.IdArticulo = idArticulo;
                return imagenVM;
            }
        }
        public async Task GuardarNuevaImagen(ImagenVM imagenVM)
        {
            Imagene? imagenExiste = await _context.Imagenes.Where(x=> x.IdArticulo == imagenVM.IdArticulo).FirstOrDefaultAsync();
            if (imagenExiste == null)
            {
                var imagenDB = new Imagene();
                imagenDB.Id = (short)imagenVM.IdImagen;
                imagenDB.Codigo = imagenVM.Codigo;
                imagenDB.IdArticulo = imagenVM.IdArticulo;
                _context.Entry(imagenDB).State = EntityState.Added;
                await _context.SaveChangesAsync();
            }
            else
            {
                imagenExiste.Codigo = imagenVM.Codigo;
                _context.Entry(imagenExiste).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            
        }
    }
}
