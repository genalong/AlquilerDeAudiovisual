
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageEvento
{
    public class EliminarModel : PageModel
    {
        public string Mensaje { get; set; } = "";
        public int Id { get; set; }
        public string Tipo { get; set; } = "";

        public IActionResult OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            Evento unEvento = unaControladora.BuscarEvento(id);

            if (unEvento == null)
            {
                return RedirectToPage("./Listar");
            }

            Id = unEvento.Id;
            Tipo = unEvento.Tipo;

            return Page();
        }

        public IActionResult OnPostEliminar()
        {
            try
            {
                if (!int.TryParse(Request.Form["id"], out int IdEvento))
                {
                    throw new Exception("El ID del Evento no es válido");
                }

                Controladora unaControladora = new Controladora();

                bool Eliminado = unaControladora.BajaEvento(IdEvento);

                if (Eliminado)
                {
                    return RedirectToPage("./Listar");
                }

                throw new Exception("No se pudo eliminar el Evento");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
    }
}
