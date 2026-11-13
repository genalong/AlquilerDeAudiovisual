
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageEvento
{
    public class AltaModel : PageModel
    {
        public string Mensaje { get; set; } = "";

        public void OnGet()
        {
        }

        public IActionResult OnPostAgregar()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID del Evento");
                }

                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID debe ser un numero");
                }

                if (Request.Form["tipo"] == "")
                {
                    throw new Exception("Debe ingresar el Tipo del Evento");
                }

                if (Request.Form["ubicacion"] == "")
                {
                    throw new Exception("Debe ingresar la Ubicacion del Evento");
                }

                if (Request.Form["fecha"] == "")
                {
                    throw new Exception("Debe ingresar la Fecha del Evento");
                }

                if (!int.TryParse(Request.Form["cantidadAsistentes"], out _))
                {
                    throw new Exception("La cantidad de asistentes debe ser un numero");
                }

                int Id = int.Parse(Request.Form["id"]);
                string Tipo = Request.Form["tipo"];
                string Ubicacion = Request.Form["ubicacion"];
                DateTime Fecha = DateTime.Parse(Request.Form["fecha"]);
                int CantidadAsistentes = int.Parse(Request.Form["cantidadAsistentes"]);

                Evento unEvento = new Evento(Id, Tipo, Ubicacion, Fecha, CantidadAsistentes);

                Controladora unaControladora = new Controladora();

                unaControladora.AltaEvento(unEvento);

                return Redirect("/PageEvento/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
    }
}
