using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PageContratacion
{
    public class ListarModel : PageModel
    {
        public List<Contratacion> ListaContrataciones { get; set; }
        public List<Cliente> ListaClientes { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            ListaContrataciones = unaControladora.ListarContrataciones();
            ListaClientes = unaControladora.ListarClientes();
        }

        public string NombreCliente(int pClienteId)
        {
            foreach (Cliente unCliente in ListaClientes)
            {
                if (unCliente.Id == pClienteId)
                {
                    return unCliente.Nombre;
                }
            }
            return "(desconocido)";
        }
    }
}