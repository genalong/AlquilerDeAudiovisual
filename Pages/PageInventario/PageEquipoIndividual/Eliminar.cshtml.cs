
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageInventario.PageEquipoIndividual
{
    public class EliminarModel : PageModel
    {
        public EquipoIndividual UnEquipo { get; set; }

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            UnEquipo = unaControladora.BuscarEquipoIndividual(id);
        }

        public IActionResult OnPostEliminar(int id)
        {
            Controladora unaControladora = new Controladora();

            if (unaControladora.BajaEquipoIndividual(id))
            {
                return RedirectToPage("./Listar");
            }

            UnEquipo = unaControladora.BuscarEquipoIndividual(id);
            return Page();
        }
    }
}
