using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PageContratacion
{
    public class EliminarModel : PageModel
    {
        public Contratacion contratacion { get; set; }

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            contratacion = unaControladora.BuscarContratacion(id);
        }

        public IActionResult OnPostEliminar()
        {
            int Id = int.Parse(Request.Form["id"]);
            Controladora unaControladora = new Controladora();
            unaControladora.BajaContratacion(Id);
            return Redirect("./Listar");
        }
    }
}