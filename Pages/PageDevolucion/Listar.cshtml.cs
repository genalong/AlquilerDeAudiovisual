using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageDevolucion
{
    public class ListarModel : PageModel
    {
        public List<Devolucion> ListaDevoluciones { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            ListaDevoluciones = unaControladora.ListarDevoluciones();
        }
    }
}