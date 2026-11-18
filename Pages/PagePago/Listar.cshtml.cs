using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PagePago
{
    public class ListarModel : PageModel
    {
        public List<Pago> ListaPagos { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            ListaPagos = unaControladora.ListarPagos();
        }
    }
}