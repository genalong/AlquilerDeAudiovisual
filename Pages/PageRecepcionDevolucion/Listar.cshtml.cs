using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageRecepcionDevolucion
{
    public class ListarModel : PageModel
    {
        public List<DetalleDevolucion> ListaDetalles { get; set; }
            = new List<DetalleDevolucion>();

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();

            ListaDetalles = unaControladora.ListarDetallesDevolucion();
        }
    }
}