using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageDevolucion
{
    public class EliminarModel : PageModel
    {
        public int Id { get; set; }
        public Devolucion UnaDevolucion { get; set; }
        public string Mensaje { get; set; } = "";

        public IActionResult OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            UnaDevolucion = unaControladora.BuscarDevolucion(id);

            if (UnaDevolucion != null)
            {
                Id = UnaDevolucion.Id;
                return Page();
            }

            return RedirectToPage("./Listar");
        }

        public IActionResult OnPostEliminar()
        {
            try
            {
                if (Request.Form["id"] == "")
                    throw new Exception("No se encontró el ID de la Devolución");

                int Id = int.Parse(Request.Form["id"]);

                Controladora unaControladora = new Controladora();

                if (!unaControladora.BajaDevolucion(Id))
                    throw new Exception("No se pudo eliminar la Devolución");

                return RedirectToPage("./Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
    }
}