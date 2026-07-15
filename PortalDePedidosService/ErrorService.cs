using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace PortalDePedidosService
{
    public class ErrorService
    {
        private NavigationManager navigation { get; set; }
        public ErrorService(NavigationManager navigation)
        {
            this.navigation = navigation;
        }
        public void Error(string codError)
        {
            navigation.NavigateTo("/error/"+codError);
        }
    }
}
