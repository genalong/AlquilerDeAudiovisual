using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageReporte
{
    public class ContratacionesPorClienteModel : PageModel
    {
        public List<string[]> Resultado { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Resultado = unaControladora.ReporteContratacionesPorCliente(
                DateTime.Now.AddYears(-1), DateTime.Now);
        }
    }
}