using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.LoginVM
{
    public class ReCaptchaVM
    {
        public string Token { get; set; }
        public string Action { get; set; }

        public ReCaptchaVM(string token, string action) 
        {
            Token = token;
            Action = action;
        }

        public ReCaptchaVM() { }
    }
}
