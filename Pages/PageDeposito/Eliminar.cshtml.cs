using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageDeposito
{
    public class EliminarModel : PageModel
    {
        public Deposito deposito { get; set; }

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            deposito = unaControladora.BuscarDeposito(id);
        }

        public IActionResult OnPostEliminar()
        {
            int Id = int.Parse(Request.Form["id"]);

            Controladora unaControladora = new Controladora();

            unaControladora.BajaDeposito(Id);

            return Redirect("./Listar");
        }
    }
}