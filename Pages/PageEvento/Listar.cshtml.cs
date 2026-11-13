using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageEvento
{
    public class ListarModel : PageModel
    {
        public List<Evento> ListaEventos { get; set; } = new List<Evento>();

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();

            ListaEventos = unaControladora.ListarEventos();
        }
    }
}
