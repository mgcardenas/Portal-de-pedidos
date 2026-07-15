namespace PortalDePedidos.Extensiones
{
    public class AppSettings
    {
        public string ApiConnection { get; set; }
        public bool AppTest { get; set; }
        public bool ReCaptcha { get; set; }
        public int MinTNGranel { get; set; }
        public int MinTNPallet { get; set; }
        public int MaxTN { get; set; }
        public int DuracionSesion { get; set; }
        public bool AppPublica { get; set; }
        public bool LogInMFA { get; set; }
        public string Version { get; set; }
    }
}
