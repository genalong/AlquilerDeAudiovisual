using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PageReporte
{
    public class ContratacionesXEquipoModel : PageModel
    {
        public List<Contratacion> Contrataciones { get; set; }
        public List<Equipamiento> Equipamientos { get; set; }
        [BindProperty] public int idEquipo { get; set; }
        public int CantEquipos { get; set; }
        public double TotalEquipo { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Equipamientos = unaControladora.ListarEquipamientos();
        }

        public IActionResult OnPostListar()
        {
            Controladora unaControladora = new Controladora();
            Contrataciones = new List<Contratacion>();

            if (idEquipo != 0)
            {
                foreach (Contratacion unaContratacion in unaControladora.ListarContrataciones())
                {
                    if (unaContratacion.EquipamientoId == idEquipo && unaContratacion.Estado == "Aprobado")
                    {
                        Contrataciones.Add(unaContratacion);
                        CantEquipos += unaContratacion.Cantidad;
                        TotalEquipo += (unaContratacion.Cantidad * unaContratacion.ImporteTotal);
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Debe seleccionar un equipamiento.");
            }
            Equipamientos = unaControladora.ListarEquipamientos();
            return Page();
        }
    }
}