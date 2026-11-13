
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageInventario.PageStockEquipamiento
{
    public class ListarModel : PageModel
    {
        public List<StockEquipamiento> ListaStockEquipamientos { get; set; } = new List<StockEquipamiento>();

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            ListaStockEquipamientos = unaControladora.ListarStockEquipamientos();
        }
    }
}
