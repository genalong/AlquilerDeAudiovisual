
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageInventario.PageEquipoIndividual
{
    public class ListarModel : PageModel
    {
        public List<EquipoIndividual> ListaEquiposIndividuales { get; set; } = new List<EquipoIndividual>();

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            ListaEquiposIndividuales = unaControladora.ListarEquiposIndividuales();
        }
    }
}
