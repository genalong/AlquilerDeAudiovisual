
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
        public string Ubicacion { get; set; } = "";
        public DateTime Fecha { get; set; }
        public int CantidadAsistentes { get; set; }

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
            Ubicacion = unEvento.Ubicacion;
            Fecha = unEvento.Fecha;
            CantidadAsistentes = unEvento.CantidadAsistentes;

            return Page();
        }

        public IActionResult OnPostModificar()
        {
            try
            {
                if (!int.TryParse(Request.Form["id"], out int IdEvento))
                    throw new Exception("El ID del Evento no es válido");

                if (Request.Form["tipo"] == "")
                    throw new Exception("Debe ingresar el Tipo del Evento");

                if (Request.Form["ubicacion"] == "")
                    throw new Exception("Debe ingresar la Ubicación del Evento");

                if (!DateTime.TryParse(Request.Form["fecha"], out DateTime FechaEvento))
                    throw new Exception("Debe ingresar una Fecha válida");

                if (!int.TryParse(Request.Form["cantidadAsistentes"], out int Cantidad))
                    throw new Exception("La cantidad de asistentes debe ser un número");

                if (Cantidad <= 0)
                    throw new Exception("La cantidad de asistentes debe ser mayor a cero");

                string TipoEvento = Request.Form["tipo"];
                string UbicacionEvento = Request.Form["ubicacion"];

                Controladora unaControladora = new Controladora();

                bool Modificado = unaControladora.ModificarEvento(
                    IdEvento,
                    TipoEvento,
                    UbicacionEvento,
                    FechaEvento,
                    Cantidad
                );

                if (Modificado)
                {
                    return RedirectToPage("./Listar");
                }

                throw new Exception("No se pudo modificar el Evento");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;

                int.TryParse(Request.Form["id"], out int IdFormulario);
                Id = IdFormulario;
                Tipo = Request.Form["tipo"];
                Ubicacion = Request.Form["ubicacion"];
                DateTime.TryParse(Request.Form["fecha"], out DateTime FechaFormulario);
                Fecha = FechaFormulario;
                int.TryParse(Request.Form["cantidadAsistentes"], out int CantidadFormulario);
                CantidadAsistentes = CantidadFormulario;

                return Page();
            }
        }
    }
}
