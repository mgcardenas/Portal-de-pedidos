using Microsoft.EntityFrameworkCore;
using PortalDePedidosServidor.Models;
using PortalDePedidosShared.ImagenesAleatoriasVM;

namespace PortalDePedidosServidor.Servicios {
    public class ImagenCarruselService {
        private PortalTestContext _context;
        private Random _random;

        public ImagenCarruselService(PortalTestContext context) {
            _context = context;
            _random = new Random();
        }

        public async Task<List<ImagenCarruselVM>> GetImagen(int cantidad) {
            List<ImagenCarruselVM> imagenesCarrusel = new();
            var imagenesDb = await _context.ImagenesCarrusels.ToListAsync();
            if(imagenesDb.Count > 0) {
                int totalImagenes = imagenesDb.Count;
                int i = 0;
                if(totalImagenes > cantidad) {
                    while(i < cantidad) {
                        var imagenDb = imagenesDb.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                        if(!imagenesCarrusel.Any(x => x.Id == imagenDb.Id)) {
                            ImagenCarruselVM imagenCarruselVM = new ImagenCarruselVM();
                            imagenCarruselVM.Id = imagenDb.Id;
                            imagenCarruselVM.Codigo = imagenDb.Codigo;
                            i++;
                            imagenesCarrusel.Add(imagenCarruselVM);
                        }
                    }
                } else {
                    imagenesDb.ForEach(x => imagenesCarrusel.Add(new ImagenCarruselVM() { Id = x.Id,Codigo = x.Codigo }));
                }
            } else {
                ImagenCarruselVM imagenAleatoriaVM = new ImagenCarruselVM();
                imagenAleatoriaVM.Id = 0;
                imagenAleatoriaVM.Codigo = "No hay imagenes";
                imagenesCarrusel.Add(imagenAleatoriaVM);
            }
            return imagenesCarrusel;
        }

        public async Task<List<ImagenCarruselVM>> GetImagenAll() {
            List<ImagenCarruselVM> imagenesCarrusel = new();
            var imagenesDb = await _context.ImagenesCarrusels.OrderBy(x => x.Id).ToListAsync();
            imagenesDb.ForEach(x => imagenesCarrusel.Add(new ImagenCarruselVM() { Id = x.Id,Codigo = x.Codigo }));
            return imagenesCarrusel;
        }

        public async Task GuardarNuevaImagen(ImagenCarruselVM imagenVM) {
            var imagenDB = new ImagenesCarrusel();
            imagenDB.Codigo = imagenVM.Codigo;
            _context.Entry(imagenDB).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
        public async Task EliminarImagen(int id) {
            var imagenDB = await _context.ImagenesCarrusels.FindAsync(id);
            _context.Entry(imagenDB).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
