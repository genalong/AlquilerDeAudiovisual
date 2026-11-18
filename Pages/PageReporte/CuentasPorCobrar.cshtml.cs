using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageReporte
{
    public class CuentasPorCobrarModel : PageModel
    {
        public List<string[]> Resultado { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Resultado = unaControladora.ReporteCuentasPorCobrar();
        }
    }
}