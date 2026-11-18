using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageDeposito
{
    public class ModificarModel : PageModel
    {
        public Deposito deposito { get; set; }
        public string Mensaje { get; set; } = "";

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            deposito = unaControladora.BuscarDeposito(id);
        }

        public IActionResult OnPostModificar()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID del Depósito");
                }

                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID del Depósito debe ser un numero");
                }

                if (Request.Form["nombre"] == "")
                {
                    throw new Exception("Debe ingresar el Nombre del Depósito");
                }

                if (Request.Form["direccion"] == "")
                {
                    throw new Exception("Debe ingresar la Dirección del Depósito");
                }

                if (Request.Form["responsable"] == "")
                {
                    throw new Exception("Debe ingresar el Responsable del Depósito");
                }

                int Id = int.Parse(Request.Form["id"]);
                string Nombre = Request.Form["nombre"];
                string Direccion = Request.Form["direccion"];
                string Responsable = Request.Form["responsable"];

                Controladora unaControladora = new Controladora();

                unaControladora.ModificarDeposito(Id, Nombre, Direccion, Responsable);

                return Redirect("/PageDeposito/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
    }
}