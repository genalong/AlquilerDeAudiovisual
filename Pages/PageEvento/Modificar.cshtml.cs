
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageEvento
{
    public class ModificarModel : PageModel
    {
        public string Mensaje { get; set; } = "";
        public int Id { get; set; }
        public string Tipo { get; set; } = "";
        public DateTime Fecha { get; set; }

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
            Fecha = unEvento.Fecha;

            return Page();
        }

        public IActionResult OnPostModificar()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID del Evento");
                }

                if (Request.Form["tipo"] == "")
                {
                    throw new Exception("Debe ingresar el Tipo del Evento");
                }

                if (Request.Form["fecha"] == "")
                {
                    throw new Exception("Debe ingresar la Fecha del Evento");
                }

                int IdEvento = int.Parse(Request.Form["id"]);
                string TipoEvento = Request.Form["tipo"];
                DateTime FechaEvento = DateTime.Parse(Request.Form["fecha"]);

                Controladora unaControladora = new Controladora();

                bool Modificado = unaControladora.ModificarEvento(
                    IdEvento, TipoEvento, FechaEvento);

                if (Modificado)
                {
                    return RedirectToPage("./Listar");
                }

                throw new Exception("No se pudo modificar el Evento");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                Id = int.Parse(Request.Form["id"]);
                Tipo = Request.Form["tipo"];
                DateTime.TryParse(Request.Form["fecha"], out DateTime fecha);
                Fecha = fecha;

                return Page();
            }
        }
    }
}
