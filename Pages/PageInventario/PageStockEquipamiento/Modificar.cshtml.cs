
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageInventario.PageStockEquipamiento
{
    public class ModificarModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public int IdEquipamiento { get; set; }

        [BindProperty]
        public int IdDeposito { get; set; }

        [BindProperty]
        public int CantidadTotal { get; set; }

        [BindProperty]
        public int CantidadDisponible { get; set; }

        public StockEquipamiento UnStock { get; set; }

        public List<Equipamiento> ListaEquipamientos { get; set; } = new List<Equipamiento>();

        public List<Deposito> ListaDepositos { get; set; } = new List<Deposito>();

        public string Mensaje { get; set; } = "";

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            CargarListas(unaControladora);

            UnStock = unaControladora.ListarStockEquipamientos()
                .FirstOrDefault(unStock => unStock.Id == id);

            if (UnStock != null)
            {
                Id = UnStock.Id;
                IdEquipamiento = UnStock.Equipamiento.Id;
                IdDeposito = UnStock.Deposito.Id;
                CantidadTotal = UnStock.CantidadTotal;
                CantidadDisponible = UnStock.CantidadDisponible;
            }
        }

        public IActionResult OnPostModificar()
        {
            Controladora unaControladora = new Controladora();

            CargarListas(unaControladora);

            UnStock = unaControladora.ListarStockEquipamientos()
                .FirstOrDefault(unStock => unStock.Id == Id);

            if (CantidadTotal < 0 || CantidadDisponible < 0 ||
                CantidadDisponible > CantidadTotal)
            {
                Mensaje = "Verifique las cantidades ingresadas.";
                return Page();
            }

            Equipamiento unEquipamiento = unaControladora.BuscarEquipamiento(IdEquipamiento);
            Deposito unDeposito = unaControladora.BuscarDeposito(IdDeposito);

            if (unEquipamiento == null || unDeposito == null)
            {
                Mensaje = "Seleccione un equipamiento y un depósito válidos.";
                return Page();
            }

            if (unaControladora.ModificarStockEquipamiento(
                unEquipamiento,
                unDeposito,
                CantidadTotal,
                CantidadDisponible))
            {
                return RedirectToPage("./Listar");
            }

            Mensaje = "No se pudo modificar el registro de stock.";
            return Page();
        }

        private void CargarListas(Controladora unaControladora)
        {
            ListaEquipamientos = unaControladora.ListarEquipamientos();
            ListaDepositos = unaControladora.ListarDepositos();
        }
    }
}
