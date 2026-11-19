using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PageSolicitud
{
    public class ListarModel : PageModel
    {
        public List<SolicitudAlquiler> ListaSolicitudes { get; set; }
        public List<Cliente> ListaClientes { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            ListaSolicitudes = unaControladora.ListarSolicitudes();
            ListaClientes = unaControladora.ListarClientes();
        }

        public string NombreCliente(int pClienteId)
        {
            if (ListaClientes == null) return "(desconocido)";
            foreach (Cliente unCliente in ListaClientes)
                if (unCliente.Id == pClienteId) return unCliente.Nombre;
            return "(desconocido)";
        }
    }
}