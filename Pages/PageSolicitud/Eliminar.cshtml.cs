
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageSolicitud
{
    public class EliminarModel : PageModel
    {
        public string Mensaje { get; set; }

        public Solicitud UnaSolicitud { get; set; }

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            UnaSolicitud = unaControladora.BuscarSolicitud(id);
        }

        public IActionResult OnPostEliminar()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("No se recibió el ID de la Solicitud");
                }

                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID de la Solicitud debe ser un numero");
                }

                int Id = int.Parse(Request.Form["id"]);

                Controladora unaControladora = new Controladora();

                if (unaControladora.BajaSolicitud(Id))
                {
                    return Redirect("/PageSolicitud/Listar");
                }

                throw new Exception("No se pudo eliminar la Solicitud");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;

                if (int.TryParse(Request.Form["id"], out int Id))
                {
                    Controladora unaControladora = new Controladora();
                    UnaSolicitud = unaControladora.BuscarSolicitud(Id);
                }

                return Page();
            }
        }
    }
}
