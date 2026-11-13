
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageInventario.PageEquipoIndividual
{
    public class ModificarModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string NumeroSerie { get; set; } = "";

        [BindProperty]
        public string Estado { get; set; } = "";

        [BindProperty]
        public int IdDeposito { get; set; }

        public EquipoIndividual UnEquipo { get; set; }

        public List<Deposito> ListaDepositos { get; set; } = new List<Deposito>();

        public string Mensaje { get; set; } = "";

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            UnEquipo = unaControladora.BuscarEquipoIndividual(id);
            ListaDepositos = unaControladora.ListarDepositos();

            if (UnEquipo != null)
            {
                Id = UnEquipo.Id;
                NumeroSerie = UnEquipo.NumeroSerie;
                Estado = UnEquipo.Estado;
            }
        }

        public IActionResult OnPostModificar()
        {
            Controladora unaControladora = new Controladora();

            Deposito unDeposito = unaControladora.BuscarDeposito(IdDeposito);

            if (unDeposito == null)
            {
                ListaDepositos = unaControladora.ListarDepositos();
                UnEquipo = unaControladora.BuscarEquipoIndividual(Id);
                Mensaje = "Debe seleccionar un depósito válido.";
                return Page();
            }

            if (unaControladora.ModificarEquipoIndividual(Id, NumeroSerie, Estado))
            {
                return RedirectToPage("./Listar");
            }

            ListaDepositos = unaControladora.ListarDepositos();
            UnEquipo = unaControladora.BuscarEquipoIndividual(Id);
            Mensaje = "No se pudo modificar el equipo individual.";

            return Page();
        }
    }
}
