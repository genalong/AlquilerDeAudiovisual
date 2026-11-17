using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AlquilerAudiovisual.Pages.PageContratacion
{
    public class ListarModel : PageModel
    {
        public List<Contratacion> ListaContrataciones { get; set; } = new List<Contratacion>();

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            ListaContrataciones = unaControladora.ListarContrataciones();
        }
    }
}