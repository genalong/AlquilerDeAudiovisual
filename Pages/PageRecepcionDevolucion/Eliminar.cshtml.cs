using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageRecepcionDevolucion
{
    public class EliminarModel : PageModel
    {
        public DetalleDevolucion UnDetalle { get; set; }

        public string Mensaje { get; set; } = "";

        public IActionResult OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            UnDetalle = unaControladora.BuscarDetalleDevolucion(id);

            if (UnDetalle == null)
            {
                return RedirectToPage("./Listar");
            }

            return Page();
        }

        public IActionResult OnPostEliminar(int id)
        {
            Controladora unaControladora = new Controladora();

            if (unaControladora.BajaDetalleDevolucion(id))
            {
                return RedirectToPage("./Listar");
            }

            Mensaje = "No se pudo eliminar el detalle de recepción";

            UnDetalle = unaControladora.BuscarDetalleDevolucion(id);

            return Page();
        }
    }
}