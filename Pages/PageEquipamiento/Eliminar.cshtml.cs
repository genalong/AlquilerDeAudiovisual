using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageEquipamiento
{
    public class EliminarModel : PageModel
    {
        public Equipamiento equipamiento { get; set; }
        public Deposito deposito { get; set; }

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            equipamiento = unaControladora.BuscarEquipamiento(id);

            if (equipamiento != null)
            {
                deposito = unaControladora.BuscarDeposito(equipamiento.DepositoId);
            }
        }

        public IActionResult OnPostEliminar()
        {
            int Id = int.Parse(Request.Form["id"]);

            Controladora unaControladora = new Controladora();

            unaControladora.BajaEquipamiento(Id);

            return Redirect("./Listar");
        }
    }
}