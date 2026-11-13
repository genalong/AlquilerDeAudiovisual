
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageDeposito
{
    public class EliminarModel : PageModel
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

        public IActionResult OnPostEliminar()
        {
            try
            {
                if (!int.TryParse(Request.Form["id"], out int IdDeposito))
                    throw new Exception("El ID del Depósito no es válido");

                Controladora unaControladora = new Controladora();

                bool Eliminado = unaControladora.BajaDeposito(IdDeposito);

                if (Eliminado)
                    return RedirectToPage("./Listar");

                throw new Exception("No se pudo eliminar el Depósito");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
    }
}
