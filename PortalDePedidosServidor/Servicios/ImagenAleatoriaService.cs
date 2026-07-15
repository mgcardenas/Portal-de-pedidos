using Microsoft.EntityFrameworkCore;
using PortalDePedidosServidor.Models;
using PortalDePedidosShared.ImagenesAleatoriasVM;

namespace PortalDePedidosServidor.Servicios
{
    public class ImagenAleatoriaService
    {
        private PortalTestContext _context;
        private Random _random;

        public ImagenAleatoriaService(PortalTestContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task<List<ImagenAleatoriaVM>> GetImagen(int cantidad)
        {
            List<ImagenAleatoriaVM> imagenesAleatorias = new();
            var imagenesDb = await _context.ImagenesAleatorias.ToListAsync();
            if (imagenesDb.Count > 0)
            {
                int totalImagenes = imagenesDb.Count;
                int i = 0;
                if(totalImagenes > cantidad) {
                    while(i < cantidad) {
                        var imagenDb = imagenesDb.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                        if(!imagenesAleatorias.Any(x => x.Id == imagenDb.Id)) {
                            ImagenAleatoriaVM imagenAleatoriaVM = new ImagenAleatoriaVM();
                            imagenAleatoriaVM.Id = imagenDb.Id;
                            imagenAleatoriaVM.Codigo = imagenDb.Codigo;
                            i++;
                            imagenesAleatorias.Add(imagenAleatoriaVM);
                        }
                    }
                } else {
                    imagenesDb.ForEach(x => imagenesAleatorias.Add(new ImagenAleatoriaVM() { Id = x.Id,Codigo = x.Codigo }));
                    }
            } else
            {
                ImagenAleatoriaVM imagenAleatoriaVM = new ImagenAleatoriaVM();
                imagenAleatoriaVM.Id = 0;
                imagenAleatoriaVM.Codigo = "No hay imagenes";
                imagenesAleatorias.Add(imagenAleatoriaVM);
            }
            return imagenesAleatorias;
        }
        public async Task<List<ImagenAleatoriaVM>> GetImagenAll() {
            List<ImagenAleatoriaVM> imagenesAleatorias = new();
            var imagenesDb = await _context.ImagenesAleatorias.OrderBy(x => x.Id).ToListAsync();
            imagenesDb.ForEach(x => imagenesAleatorias.Add(new ImagenAleatoriaVM() { Id = x.Id,Codigo = x.Codigo }));
            return imagenesAleatorias;
        }

        public async Task GuardarNuevaImagen(ImagenAleatoriaVM imagenVM) {
            var imagenDB = new ImagenesAleatoria();
            imagenDB.Codigo = imagenVM.Codigo;
            _context.Entry(imagenDB).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
        public async Task EliminarImagen(int id) {
            var imagenDB = await _context.ImagenesAleatorias.FindAsync(id);
            _context.Entry(imagenDB).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
