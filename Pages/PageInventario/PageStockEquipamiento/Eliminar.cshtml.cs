
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageInventario.PageStockEquipamiento
{
    public class EliminarModel : PageModel
    {
        public int Id { get; set; }

        public EquipoPorCantidad UnStock { get; set; }

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            Id = id;

            UnStock = unaControladora.ListarStockEquipamientos()
                .Find(unStock => unStock.Id == id);
        }

        public IActionResult OnPostEliminar()
        {
            Controladora unaControladora = new Controladora();

            UnStock = unaControladora.ListarStockEquipamientos()
                .Find(unStock => unStock.Id == Id);

            if (UnStock != null)
            {
                if (unaControladora.BajaStockEquipamiento(Id))
                {
                    return RedirectToPage("./Listar");
                }
            }

            return Page();
        }
    }
}
