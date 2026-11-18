using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageReporte
{
    public class IncidenciasModel : PageModel
    {
        public List<string[]> Resultado { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Resultado = unaControladora.ReporteIncidencias();
        }
    }
}