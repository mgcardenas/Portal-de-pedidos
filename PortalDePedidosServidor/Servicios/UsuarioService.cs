using Google.Type;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortalDePedidosModel;
using PortalDePedidosServidor.Models;
using PortalDePedidosServidor.ModelsDataWhereHouse;
using PortalDePedidosShared.UsuariosVM;

namespace PortalDePedidosServidor.Servicios
{
    public class UsuarioService
    {
        private PortalTestContext _context;
        private DataWareHouseService _dataWhereHouseService;

        public UsuarioService(PortalTestContext context, DataWareHouseService dataWhereHouseService)
        {
            _context = context;
            _dataWhereHouseService = dataWhereHouseService;
        }

        public async Task<List<UsuarioVM>> GetAllUsuarios()
        {
            List<UsuarioVM> list = new List<UsuarioVM>();   

            var usuariosDB = await _context.Usuarios.ToListAsync();

            foreach(var usuario in usuariosDB)
            {
                var usuarioVM = new UsuarioVM
                {
                    id = usuario.IdUsuario,
                    nombreUsuario = usuario.NombreUsuario,
                    nroUsuarioJDE = usuario.UsuarioOracle,
                    mail = usuario.MailUsuario,
                    fechaUltimaVisita = usuario.FechaUltimaVisita,
                    envioFactura = (usuario.HabilitadoEnvioMail == 1),
                    envioRecibo = (usuario.HabilitadoEnvioRecibos == 1),
                    moneda = usuario.Moneda
                };

                LibroDireccione? UsuarioJDE = await _dataWhereHouseService.GetUsuarioJDE(usuario.UsuarioOracle);
                if (UsuarioJDE != null)
                {
                    usuarioVM.razonSocial = UsuarioJDE.RazonSocial;
                }

                list.Add(usuarioVM);
            }


            return list.OrderBy(x=> x.nombreUsuario).ToList();
        }



        public async Task<List<UsuarioVM>> GetUsuariosClientesOptimizado()
        {
            var usuariosDB = await _context.Usuarios
    .Where(x => x.IdRol == 2 || x.IdRol == 3)
    .ToListAsync();

            var codigos = usuariosDB
                .Select(u => u.UsuarioOracle)
                .Distinct()
                .ToList();

            // Traer todos los usuarios JDE en un solo llamado
            var usuariosJDE = _dataWhereHouseService.GetUsuariosJDE();

            var list = usuariosDB.Select(usuarioDB =>
            {
                var usuarioVM = new UsuarioVM
                {
                    id = usuarioDB.IdUsuario,
                    nombreUsuario = usuarioDB.NombreUsuario,
                    nroUsuarioJDE = usuarioDB.UsuarioOracle,
                    mail = usuarioDB.MailUsuario,
                    fechaUltimaVisita = usuarioDB.FechaUltimaVisita,
                    envioFactura = usuarioDB.HabilitadoEnvioMail == 1,
                    envioRecibo = usuarioDB.HabilitadoEnvioRecibos == 1,
                    codZona = usuarioDB.CodZona,
                    moneda = usuarioDB.Moneda,
                    areaDeVenta = usuarioDB.AreaVenta ?? 1
                };

                var usuarioJDE = usuariosJDE.FirstOrDefault(x => x.CodLibroDireccion.ToString() == usuarioDB.UsuarioOracle);
                if (usuarioJDE != null)
                    usuarioVM.razonSocial = usuarioJDE.RazonSocial;

                return usuarioVM;
            })
            .OrderBy(x => x.nombreUsuario)
            .ToList();

            return list;

        }
        public async Task<List<UsuarioVM>> GetUsuariosClientes()
        {
            List<UsuarioVM> list = new List<UsuarioVM>();

            var usuariosDB = await _context.Usuarios.Where(x=> x.IdRol == 2 || x.IdRol == 3).ToListAsync();

            foreach (var usuarioDB in usuariosDB)
            {
                var usuarioVM = new UsuarioVM
                {
                    id = usuarioDB.IdUsuario,
                    nombreUsuario = usuarioDB.NombreUsuario,
                    nroUsuarioJDE = usuarioDB.UsuarioOracle,
                    mail = usuarioDB.MailUsuario,
                    fechaUltimaVisita = usuarioDB.FechaUltimaVisita,
                    envioFactura = (usuarioDB.HabilitadoEnvioMail == 1),
                    envioRecibo = (usuarioDB.HabilitadoEnvioRecibos == 1),
                    codZona = usuarioDB.CodZona,
                    moneda=usuarioDB.Moneda
                };
                if (usuarioDB.AreaVenta != null && usuarioDB.AreaVenta != 0)
                {
                    usuarioVM.areaDeVenta = (int)usuarioDB.AreaVenta;
                }
                else
                {
                    //por defecto comodoro
                    usuarioVM.areaDeVenta = 1;
                } 

                LibroDireccione? UsuarioJDE = await _dataWhereHouseService.GetUsuarioJDE(usuarioDB.UsuarioOracle);
                if (UsuarioJDE != null)
                {
                    usuarioVM.razonSocial = UsuarioJDE.RazonSocial;
                }

                list.Add(usuarioVM);
            }


            return list.OrderBy(x=> x.nombreUsuario).ToList();
        }


        public async Task<UsuarioVM> Get(int id)
        {
            UsuarioVM usuarioVM = new();

            var usuarioDB = await _context.Usuarios.SingleAsync(x => x.IdUsuario == id);

            if (usuarioDB != null)
            {
                usuarioVM = new UsuarioVM
                {
                    id = usuarioDB.IdUsuario,
                    nombreUsuario = usuarioDB.NombreUsuario,
                    nroUsuarioJDE = usuarioDB.UsuarioOracle,
                    mail = usuarioDB.MailUsuario,
                    fechaUltimaVisita = usuarioDB.FechaUltimaVisita,
                    envioFactura = (usuarioDB.HabilitadoEnvioMail == 1),
                    envioRecibo = (usuarioDB.HabilitadoEnvioRecibos == 1),
                    moneda = usuarioDB.Moneda
                };

                if (usuarioDB.AreaVenta != null && usuarioDB.AreaVenta != 0)
                {
                    usuarioVM.areaDeVenta = (int)usuarioDB.AreaVenta;
                }
                else
                {
                    //por defecto comodoro
                    usuarioVM.areaDeVenta = 1;
                }
            }

            return usuarioVM;
        }

        public async Task<UsuarioVM> GetUsuarioPorNroJDE(string id)
        {
            UsuarioVM usuarioVM = new();

            LibroDireccione? usuarioDB = await _dataWhereHouseService.GetUsuarioJDE(id);
            var usuarioDBLocal = await _context.Usuarios.SingleAsync(x => x.UsuarioOracle == id.ToString());

            if (usuarioDB != null)
            {
                usuarioVM = new UsuarioVM
                {
                    id = usuarioDBLocal != null ? usuarioDBLocal.IdUsuario:0,
                    nombreUsuario = usuarioDB.RazonSocial,
                    nroUsuarioJDE = usuarioDB.CodLibroDireccion.ToString(),
                    mail = usuarioDBLocal != null ? usuarioDBLocal.MailUsuario : "",
                    fechaUltimaVisita = usuarioDBLocal != null ? usuarioDBLocal.FechaUltimaVisita : System.DateTime.MinValue,
                    //envioFactura = (usuarioDB.HabilitadoEnvioMail == 1),
                    //envioRecibo = (usuarioDB.HabilitadoEnvioRecibos == 1),
                    codZona = usuarioDBLocal != null ? usuarioDBLocal.CodZona : "",
                    moneda = usuarioDBLocal != null ? usuarioDBLocal.Moneda : ""
                };
                //if(usuarioDB.AreaVenta != null && usuarioDB.AreaVenta != 0)
                //{
                //    usuarioVM.areaDeVenta = (int)usuarioDB.AreaVenta;
                //}
                //else
                //{
                //    //por defecto comodoro
                //    usuarioVM.areaDeVenta=1;
                //}
            }

            return usuarioVM;
        }

        public async Task<UsuarioVM> GetUsuarioPorNroJDE(ClavesUsuarioJDE clave)
        {
            UsuarioVM usuarioVM = new();

            LibroDireccione? usuarioDB = await _dataWhereHouseService.GetUsuarioJDE(clave.nroJDE);
            var usuarioDBLocal = await _context.Usuarios.SingleAsync(x => x.IdUsuario == clave.id);

            if (usuarioDB != null)
            {
                usuarioVM = new UsuarioVM
                {
                    id = usuarioDBLocal != null ? usuarioDBLocal.IdUsuario : 0,
                    nombreUsuario = usuarioDBLocal.NombreUsuario,
                    razonSocial = usuarioDB.RazonSocial,
                    nroUsuarioJDE = usuarioDB.CodLibroDireccion.ToString(),
                    mail = usuarioDBLocal != null ? usuarioDBLocal.MailUsuario : "",
                    fechaUltimaVisita = usuarioDBLocal != null ? usuarioDBLocal.FechaUltimaVisita : System.DateTime.MinValue,
                    codZona = usuarioDBLocal != null ? usuarioDBLocal.CodZona : "",
                    moneda = usuarioDBLocal != null ? usuarioDBLocal.Moneda : "",
                };
            }

            return usuarioVM;
        }

        public async Task<UsuarioEditarVM> GetUsuarioEditar(int id)
        {
            UsuarioEditarVM usuarioVM = new();

            var usuarioDB = await _context.Usuarios.SingleAsync(x => x.IdUsuario == id);

            if (usuarioDB != null)
            {
                var usrEditar = new UsuarioEditarVM
                {
                    IdUsuario = usuarioDB.IdUsuario,
                    NombreUsuario = usuarioDB.NombreUsuario,
                    NroClienteJDE = usuarioDB.UsuarioOracle,
                    RazonSocial = "",
                    MailUsuario = usuarioDB.MailUsuario,
                    IdRol = usuarioDB.IdRol,
                    FechaUltimoIngreso = usuarioDB.FechaUltimaVisita.ToString("dd/MM/yyyy H:mm:ss"),
                    HabilitadoCampoDeCargaOC = (usuarioDB.CargaInstEntrega == 1),
                    AreaVenta = AreaDeVentaManager.GetAreaDeVenta(usuarioDB.AreaVenta),
                    CodZona = usuarioDB.CodZona,
                    HabilitadoParaIngresar = (usuarioDB.RegistroAnulado == 0),
                    HabilitadoPedidos = (usuarioDB.HabilitadoPedidos == 1),
                    Moneda = usuarioDB.Moneda
                };

                LibroDireccione? UsuarioJDE = await _dataWhereHouseService.GetUsuarioJDE(usuarioDB.UsuarioOracle);
                if (UsuarioJDE != null)
                {
                    usrEditar.RazonSocial = UsuarioJDE.RazonSocial;
                }

                switch (usuarioDB.ConfigFlete)
                {
                    //Flete PCR - Gestion Logistica
                    case 1:
                        usrEditar.FleteEnviadoPor = FleteEnviadoPor.PCR; 
                        usrEditar.FleteAbonadoEn = FleteAbonadoEn.PCR; 
                        break;
                    //Flete PCR - Gestion Cliente
                    case 2:
                        usrEditar.FleteEnviadoPor = FleteEnviadoPor.PCR; 
                        usrEditar.FleteAbonadoEn = FleteAbonadoEn.LugarDeEntrega; 
                        break;
                    //Flete Cliente - Gestion Logistica
                    case 3:
                        usrEditar.FleteEnviadoPor = FleteEnviadoPor.CLIENTE;
                        usrEditar.FleteAbonadoEn = FleteAbonadoEn.PCR;
                        break;
                    //Flete Cliente - Gestion Cliente
                    case 4:
                        usrEditar.FleteEnviadoPor = FleteEnviadoPor.CLIENTE;
                        usrEditar.FleteAbonadoEn = FleteAbonadoEn.LugarDeEntrega;
                        break;
                }

                return usrEditar;
            }

            return usuarioVM;
        }

        public async Task<List<UsuarioVM>> Buscar(FiltroUsuarios filtro)
        {
            List<UsuarioVM> list = new List<UsuarioVM>();

            var query = _context.Usuarios.AsQueryable();

            if(!string.IsNullOrWhiteSpace(filtro.nombreUsuario))
                query = query.Where(x => x.NombreUsuario == filtro.nombreUsuario);

            if (filtro.nroUsuarioJDE != 0 && filtro.nroUsuarioJDE.HasValue)
                query = query.Where(x => x.UsuarioOracle == filtro.nroUsuarioJDE.ToString());

            var usuariosDB = await query.ToListAsync();

            list = usuariosDB.Select(x => new UsuarioVM
            {
                id = x.IdUsuario,
                nombreUsuario = x.NombreUsuario,
                nroUsuarioJDE = x.UsuarioOracle,
                mail = x.MailUsuario,
                fechaUltimaVisita = x.FechaUltimaVisita,
                envioFactura = (x.HabilitadoEnvioMail == 1),
                envioRecibo = (x.HabilitadoEnvioRecibos == 1),
                moneda = x.Moneda
            }).ToList();

            return list;
        }

        public async Task<List<RolVM>> GetAllRol()
        {
            var rolesDB = await _context.Rols.ToListAsync();
            var roles = rolesDB.Select(x => new RolVM()
            {
                IdRol = x.IdRol,
                NombreRol = x.NombreRol,
            }).ToList();
            
            return roles;
        }

        public async Task GuardarNuevoUsuario(UsuarioAltaVM usuarioAltaVM)
        {
            //var ultimoUsr = await _context.Usuarios.OrderByDescending(x => x.IdUsuario).FirstAsync();
            var usuarioDB = new Usuario();
            //usuarioDB.IdUsuario =(short) (ultimoUsr.IdUsuario + 1);
            usuarioDB.NombreUsuario = usuarioAltaVM.NombreUsuario;
            usuarioDB.MailUsuario = usuarioAltaVM.MailUsuario;
            usuarioDB.UsuarioOracle = usuarioAltaVM.NroClienteJDE.ToString();
            usuarioDB.PasswordUsuario = Encrypt.GetSHA1(usuarioAltaVM.Contrasena);
            usuarioDB.IdRol = usuarioAltaVM.IdRol;
            //variables por defecto igual a portal anterior
            usuarioDB.RegistroAnulado = 0;
            usuarioDB.HabilitadoEnvioMail = 1;
            usuarioDB.HabilitadoEnvioRecibos = 1;
            usuarioDB.HabilitadoPedidos = 1;
            usuarioDB.BloquearConfFlete = 0;
            usuarioDB.ConfigFlete = 1;
            usuarioDB.CodZona = "CRD";
            usuarioDB.FechaUltimaVisita =System.DateTime.Now;
            usuarioDB.Moneda = usuarioAltaVM.Moneda;

            _context.Entry(usuarioDB).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EditarUsuario(UsuarioEditarVM usuarioEditarVM)
        {
            Usuario usuarioDB = await _context.Usuarios.SingleAsync(x => x.IdUsuario == usuarioEditarVM.IdUsuario);
            if (usuarioDB != null)
            {
                usuarioDB.MailUsuario = usuarioEditarVM.MailUsuario;
                usuarioDB.IdRol = usuarioEditarVM.IdRol;
                usuarioDB.RegistroAnulado =Conversiones.ConvertirBoolAByte(!usuarioEditarVM.HabilitadoParaIngresar);
                usuarioDB.HabilitadoPedidos =Conversiones.ConvertirBoolAByte(usuarioEditarVM.HabilitadoPedidos);
                usuarioDB.CodZona = usuarioEditarVM.CodZona;
                usuarioDB.ConfigFlete =(short)Conversiones.ConfigurarFlete(usuarioEditarVM.FleteEnviadoPor, usuarioEditarVM.FleteAbonadoEn);
                usuarioDB.CargaInstEntrega = Conversiones.ConvertirBoolAByte(usuarioEditarVM.HabilitadoCampoDeCargaOC);
                usuarioDB.AreaVenta = AreaDeVentaManager.GetIntAreaDeVenta(usuarioEditarVM.AreaVenta);
                usuarioDB.Moneda = usuarioEditarVM.Moneda;
                _context.Entry(usuarioDB).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> NombreUsuarioExiste(string nombreUsuario)
        {
            var userDB = await _context.Usuarios.Where(x => x.NombreUsuario == nombreUsuario).FirstOrDefaultAsync();
            
            return userDB != null;
        }

    }
}
