
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageInventario.PageStockEquipamiento
{
    public class AltaModel : PageModel
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

        public List<Equipamiento> ListaEquipamientos { get; set; } = new List<Equipamiento>();

        public List<Deposito> ListaDepositos { get; set; } = new List<Deposito>();

        public string Mensaje { get; set; } = "";

        public void OnGet()
        {
            CargarListas();
        }

        public IActionResult OnPostAgregar()
        {
            CargarListas();

            if (Id <= 0 || IdEquipamiento <= 0 || IdDeposito <= 0 ||
                CantidadTotal < 0 || CantidadDisponible < 0 ||
                CantidadDisponible > CantidadTotal)
            {
                Mensaje = "Verifique los datos ingresados. La cantidad disponible no puede superar la cantidad total.";
                return Page();
            }

            Controladora unaControladora = new Controladora();

            Equipamiento unEquipamiento = unaControladora.BuscarEquipamiento(IdEquipamiento);
            Deposito unDeposito = unaControladora.BuscarDeposito(IdDeposito);

            if (unEquipamiento == null || unDeposito == null)
            {
                Mensaje = "El equipamiento o el depósito seleccionado no existe.";
                return Page();
            }

            StockEquipamiento unStock = new StockEquipamiento(
                Id,
                CantidadTotal,
                CantidadDisponible,
                unEquipamiento,
                unDeposito
            );

            if (unaControladora.AltaStockEquipamiento(unStock))
            {
                return RedirectToPage("./Listar");
            }

            Mensaje = "No se pudo registrar el stock. Verifique que no exista previamente.";
            return Page();
        }

        private void CargarListas()
        {
            Controladora unaControladora = new Controladora();

            ListaEquipamientos = unaControladora.ListarEquipamientos();
            ListaDepositos = unaControladora.ListarDepositos();
        }
    }
}
