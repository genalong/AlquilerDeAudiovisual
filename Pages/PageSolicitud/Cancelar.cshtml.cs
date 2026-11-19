using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PageSolicitud
{
    public class CancelarModel : PageModel
    {
        public SolicitudAlquiler solicitud { get; set; }

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            solicitud = unaControladora.BuscarSolicitud(id);
        }

        public IActionResult OnPostCancelar()
        {
            int Id = int.Parse(Request.Form["id"]);

            Controladora unaControladora = new Controladora();

            SolicitudAlquiler laSolicitud = unaControladora.BuscarSolicitud(Id);

            if (laSolicitud != null)
            {
                unaControladora.ModificarSolicitud(
                    laSolicitud.Id,
                    laSolicitud.ClienteId,
                    laSolicitud.TipoEvento,
                    laSolicitud.NombreEvento,
                    laSolicitud.FechaInicio,
                    laSolicitud.FechaFin,
                    laSolicitud.Ubicacion,
                    laSolicitud.CantidadAsistentes,
                    "Cancelada");
            }

            return Redirect("/PageSolicitud/Listar");
        }
    }
}