
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageDeposito
{
    public class ModificarModel : PageModel
    {
        public string Mensaje { get; set; } = "";
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Direccion { get; set; } = "";

        public IActionResult OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            Deposito unDeposito = unaControladora.BuscarDeposito(id);

            if (unDeposito == null)
                return RedirectToPage("./Listar");

            Id = unDeposito.Id;
            Nombre = unDeposito.Nombre;
            Direccion = unDeposito.Direccion;

            return Page();
        }

        public IActionResult OnPostModificar()
        {
            try
            {
                if (!int.TryParse(Request.Form["id"], out int IdDeposito))
                    throw new Exception("El ID del Depósito no es válido");

                if (Request.Form["nombre"] == "")
                    throw new Exception("Debe ingresar el Nombre del Depósito");

                if (Request.Form["direccion"] == "")
                    throw new Exception("Debe ingresar la Dirección del Depósito");

                string NombreDeposito = Request.Form["nombre"];
                string DireccionDeposito = Request.Form["direccion"];

                Controladora unaControladora = new Controladora();

                bool Modificado = unaControladora.ModificarDeposito(
                    IdDeposito, NombreDeposito, DireccionDeposito);

                if (Modificado)
                    return RedirectToPage("./Listar");

                throw new Exception("No se pudo modificar el Depósito");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;

                int.TryParse(Request.Form["id"], out int IdFormulario);
                Id = IdFormulario;
                Nombre = Request.Form["nombre"];
                Direccion = Request.Form["direccion"];

                return Page();
            }
        }
    }
}
