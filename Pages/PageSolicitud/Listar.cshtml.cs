using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageSolicitud
{
    public class ListarModel : PageModel
    {
        public List<Solicitud> ListaSolicitudes { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            ListaSolicitudes = unaControladora.ListarSolicitudes();
        }
    }
}