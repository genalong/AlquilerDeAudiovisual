using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageDeposito
{
    public class ListarModel : PageModel
    {
        public List<Deposito> ListaDepositos { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();

            ListaDepositos = unaControladora.ListarDepositos();
        }
    }
}