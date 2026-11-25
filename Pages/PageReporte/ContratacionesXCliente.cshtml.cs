using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PageReporte
{
    public class ContratacionesXClienteModel : PageModel
    {
        public List<Contratacion> Contrataciones { get; set; }
        public List<Cliente> Clientes { get; set; }
        [BindProperty] public int idCliente { get; set; }
        public double TotalCliente { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Clientes = unaControladora.ListarClientes();
        }

        public IActionResult OnPostListar()
        {
            Controladora unaControladora = new Controladora();
            if (idCliente != 0)
            {
                Contrataciones = new List<Contratacion>();
                foreach (Contratacion unaContratacion in unaControladora.ListarContrataciones())
                {
                    if (unaContratacion.ClienteId == idCliente)
                    {
                        Contrataciones.Add(unaContratacion);
                        TotalCliente += unaContratacion.ImporteTotal;
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Debe seleccionar un cliente.");
            }
            Clientes = unaControladora.ListarClientes();
            return Page();
        }
    }
}