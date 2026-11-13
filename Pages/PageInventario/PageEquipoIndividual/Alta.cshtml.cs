
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageInventario.PageEquipoIndividual
{
    public class AltaModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string NumeroSerie { get; set; } = "";

        [BindProperty]
        public string Estado { get; set; } = "";

        [BindProperty]
        public int IdDeposito { get; set; }

        public List<Deposito> ListaDepositos { get; set; } = new List<Deposito>();

        public string Mensaje { get; set; } = "";

        public void OnGet()
        {
            CargarDepositos();
        }

        public IActionResult OnPostAgregar()
        {
            CargarDepositos();

            if (Id <= 0 || string.IsNullOrWhiteSpace(NumeroSerie) ||
                string.IsNullOrWhiteSpace(Estado) || IdDeposito <= 0)
            {
                Mensaje = "Debe completar todos los campos.";
                return Page();
            }

            Controladora unaControladora = new Controladora();

            Deposito unDeposito = unaControladora.BuscarDeposito(IdDeposito);

            if (unDeposito == null)
            {
                Mensaje = "El depósito seleccionado no existe.";
                return Page();
            }

            EquipoIndividual unEquipo = new EquipoIndividual(
                Id,
                NumeroSerie,
                Estado,
                unDeposito
            );

            if (unaControladora.AltaEquipoIndividual(unEquipo))
            {
                return RedirectToPage("./Listar");
            }

            Mensaje = "Ya existe un equipo individual con ese ID.";
            return Page();
        }

        private void CargarDepositos()
        {
            Controladora unaControladora = new Controladora();
            ListaDepositos = unaControladora.ListarDepositos();
        }
    }
}
