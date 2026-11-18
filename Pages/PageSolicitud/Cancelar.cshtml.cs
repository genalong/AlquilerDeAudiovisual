using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
                laSolicitud.Estado = "Cancelada";
                unaControladora.ModificarSolicitud(laSolicitud);   
            }

            return Redirect("./Listar");
        }
    }
}