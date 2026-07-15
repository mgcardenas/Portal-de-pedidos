using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.LoginVM
{
    public class OlvideContrasenaVM
    {
        public int id { get; set; } = 0;
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string nombreUsuario { get; set; } = string.Empty;
        public string path { get; set; } = string.Empty;    
    }
}
