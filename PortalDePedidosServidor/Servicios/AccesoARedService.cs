using System.Net;
using System.Runtime.InteropServices;

namespace PortalDePedidosServidor.Servicios
{
    public class AccesoARedService
    {
        public string networkPath {  get; set; }
        private NetworkCredential _networkCredential;

        public AccesoARedService(string networkName, NetworkCredential credentials)
        {
            networkPath = networkName;
            _networkCredential = credentials;

            
        }

        public void IniciarAcceso()
        {
            var netResource = new NetResource
            {
                Scope = ResourceScope.GlobalNetwork,
                ResourceType = ResourceType.Disk,
                DisplayType = ResourceDisplayType.Share,
                RemoteName = networkPath,
            };

            var result = WNetAddConnection2(netResource, _networkCredential.Password, _networkCredential.UserName, 0);

            //if (result != 0)
            //{
            //    throw new Exception("Error connecting to remote share");
            //}
        }

        ~AccesoARedService()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            WNetCancelConnection2(networkPath, 0, true);
        }

        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2(NetResource netResource, string password, string username, int flags);

        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2(string name, int flags, bool force);

        [StructLayout(LayoutKind.Sequential)]
        private class NetResource
        {
            public ResourceScope Scope;
            public ResourceType ResourceType;
            public ResourceDisplayType DisplayType;
            public int Usage;
            public string LocalName;
            public string RemoteName;
            public string Comment;
            public string Provider;
        }

        private enum ResourceScope : int
        {
            Connected = 1,
            GlobalNetwork,
            Remembered,
            Recent,
            Context
        }

        private enum ResourceType : int
        {
            Any = 0,
            Disk = 1,
            Print = 2,
            Reserved = 8,
        }

        private enum ResourceDisplayType : int
        {
            Generic = 0x0,
            Domain = 0x01,
            Server = 0x02,
            Share = 0x03,
            File = 0x04,
            Group = 0x05,
            Network = 0x06,
            Root = 0x07,
            Shareadmin = 0x08,
            Directory = 0x09,
            Tree = 0x0a,
            Ndscontainer = 0x0b
        }
    }
}
