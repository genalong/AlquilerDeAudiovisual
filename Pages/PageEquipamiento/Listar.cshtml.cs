
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageEquipamiento
{
    public class ListarModel : PageModel
    {
        public List<Equipamiento> ListaEquipamientos { get; set; } = new List<Equipamiento>();

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();

            ListaEquipamientos = unaControladora.ListarEquipamientos();
        }
    }
}
