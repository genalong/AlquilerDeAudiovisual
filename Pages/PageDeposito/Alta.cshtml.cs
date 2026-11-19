using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PageDeposito
{
    public class AltaModel : PageModel
    {
        public string Mensaje { get; set; }
        public int id { get; set; } = 0;

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            id = unaControladora.ProximoIdDeposito();
        }

        public IActionResult OnPostAgregar()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID del Deposito");
                }
                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID del Deposito debe ser un numero");
                }
                if (Request.Form["nombre"] == "")
                {
                    throw new Exception("Debe ingresar el Nombre del Deposito");
                }
                if (Request.Form["direccion"] == "")
                {
                    throw new Exception("Debe ingresar la Direccion del Deposito");
                }
                if (Request.Form["responsable"] == "")
                {
                    throw new Exception("Debe ingresar el Responsable del Deposito");
                }

                int Id = int.Parse(Request.Form["id"]);
                string Nombre = Request.Form["nombre"];
                string Direccion = Request.Form["direccion"];
                string Responsable = Request.Form["responsable"];

                Deposito unDeposito = new Deposito(Id, Nombre, Direccion, Responsable);

                Controladora unaControladora = new Controladora();

                unaControladora.AltaDeposito(unDeposito);

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