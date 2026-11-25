using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PageReporte
{
    public class ContratacionesXFechaModel : PageModel
    {
        public List<Contratacion> Contrataciones { get; set; }
        [BindProperty] public DateTime fechaDesde { get; set; }
        [BindProperty] public DateTime fechaHasta { get; set; }
        public double TotalVendido { get; set; }

        public void OnGet()
        {
            fechaDesde = DateTime.Now.AddDays(-7);
            fechaHasta = DateTime.Now;
        }

        public IActionResult OnPostListar()
        {
            Controladora unaControladora = new Controladora();
            Contrataciones = new List<Contratacion>();

            foreach (Contratacion unaContratacion in unaControladora.ListarContrataciones())
            {
                if (unaContratacion.FechaInicio >= fechaDesde && unaContratacion.FechaFin <= fechaHasta)
                {
                    Contrataciones.Add(unaContratacion);
                    TotalVendido += unaContratacion.ImporteTotal;
                }
            }
            return Page();
        }
    }
}