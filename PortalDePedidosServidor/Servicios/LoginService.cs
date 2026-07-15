using PortalDePedidosServidor.Models;
using PortalDePedidosShared.LoginVM;
using PortalDePedidosShared;
using PortalDePedidosModel;
using Microsoft.EntityFrameworkCore;
using System.DirectoryServices;
using Google.Api;
using PortalDePedidosShared.UsuariosVM;
using PortalDePedidosServidor.ModelsDataWhereHouse;

namespace PortalDePedidosServidor.Servicios
{
    public class LoginService
    {
        private PortalTestContext _context;
        private IConfiguration _configuration;
        private DataWareHouseService _dataWareHouseService;
        private TokenBlacklistService _tokenBlacklistService;
        public LoginService(PortalTestContext context, IConfiguration configuration, DataWareHouseService dataWareHouseService, TokenBlacklistService tokenBlacklistService)
        {
            _context = context;
            _configuration = configuration;
            _dataWareHouseService = dataWareHouseService;
            _tokenBlacklistService = tokenBlacklistService;
        }

       

        public async Task<bool> RecuperarContrasena(RecuperarContrasenaVM recuperarVM)
        {
            Usuario usuarioDB = await _context.Usuarios.SingleAsync(x => x.IdUsuario == recuperarVM.Id);
            
            if (usuarioDB != null)
            {
                usuarioDB.PasswordUsuario = Encrypt.GetSHA1(recuperarVM.Contrasena);
                usuarioDB.FechaUltimaContrasena =DateTime.Now.Date;
                _context.Entry(usuarioDB).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<SesionUsuario?> LoginAD(UsuarioLogIn credentials)
        {
            //Acá busco autenticar User + Pass contra el AD y si me devuelve true, recién ahí busco su nivel en la DB.
            var connAd = _configuration.GetConnectionString("ConexionAD");
            
            DirectoryEntry de = new DirectoryEntry(connAd, credentials.userName, credentials.password);
            DirectorySearcher dsearch = new DirectorySearcher(de);
            SearchResult results = null;

            results = dsearch.FindOne();


            if( results != null)
            {
                var userDB = await _context.Usuarios.Include(x => x.IdRolNavigation).Where(x => x.NombreUsuario == credentials.userName && x.RegistroAnulado == 0).FirstOrDefaultAsync();
                var sesion = await CrearSesion(userDB);
                if (sesion != null)
                {
                    sesion.Contrasena = credentials.password;
                    return sesion;
                }
            }
            
            return null;
            

        }
        
        public async Task<SesionUsuario?> LoginBD(UsuarioLogIn credentials)
        {
            var userDB = await _context.Usuarios.Include(x => x.IdRolNavigation).Where(x => x.NombreUsuario == credentials.userName && x.RegistroAnulado == 0).FirstOrDefaultAsync();
            var passSha1 = Encrypt.GetSHA1(credentials.password);

            if (userDB != null && userDB.PasswordUsuario == passSha1)
            {
                var sesion = await CrearSesion(userDB);
                if (sesion != null)
                {
                    sesion.Contrasena = credentials.password;
                    return sesion;
                }
            }
            return null;
        }

        public async Task Logout(string token)
        {
           _tokenBlacklistService.AddToBlacklist(token);
        }

        public async Task<SesionUsuario?> CrearSesion(Usuario? userDB)
        {
            //var userDB = await _context.Usuarios.Include(x => x.IdRolNavigation).Where(x => x.NombreUsuario == credentials.userName && x.RegistroAnulado == 0).FirstOrDefaultAsync();
            if (userDB != null)
            {
                var usuario = new SesionUsuario();
                usuario.Id = userDB.IdUsuario;
                usuario.NroUsuarioJDE = userDB.UsuarioOracle;
                usuario.NombreUsuario = userDB.NombreUsuario;
                usuario.Correo = userDB.MailUsuario;
                usuario.Rol = userDB.IdRolNavigation.NombreRol;
                //marco fecha ultima visita
                userDB.FechaUltimaVisita = DateTime.Now;

                //marco fecha de ultima contraseña si no la tiene
                if (userDB.FechaUltimaContrasena == null)
                    userDB.FechaUltimaContrasena = DateTime.Now.Date;

                _context.Entry(userDB).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                //Verifico la caducidad de contraseña
                var caducidad = int.Parse(_configuration.GetConnectionString("CaducidadDeContrasena"));
                var fechaCaducidad = ((DateTime) userDB.FechaUltimaContrasena).AddDays(caducidad); 
                usuario.ContrasenaExpirada = DateTime.Now.Date >= fechaCaducidad;
                

                //obtengo permisos del usuario
                var permisos = await _context.RolPermisos.Where(x => x.IdRol == userDB.IdRol).ToListAsync();
                permisos.ForEach(x =>
                usuario.Permisos.Add(PermisosManager.GetPermiso(x.IdPermiso))
                );

                //verifico si el cliente tiene deuda
                if(usuario.Rol != "Comercial")
                {
                    usuario.TieneDeuda = await _dataWareHouseService.ClienteTieneDeuda(int.Parse(usuario.NroUsuarioJDE));
                }

                //busco rubro del usuario
                var cliente = await _dataWareHouseService.GetCliente(int.Parse(usuario.NroUsuarioJDE));
                if(cliente != null)
                {
                    usuario.CodRubroCliente = cliente.CodRubroCliente;
                }
                return usuario;
            }
            return null;
        }
    }
}
