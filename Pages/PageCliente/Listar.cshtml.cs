
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageCliente
{
    public class ListarModel : PageModel
    {
        public List<Cliente> ListaClientes { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();

            ListaClientes = unaControladora.ListarClientes();
        }
    }
}
