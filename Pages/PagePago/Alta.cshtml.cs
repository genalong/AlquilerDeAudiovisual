using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PagePago
{
    public class AltaModel : PageModel
    {
        public string Mensaje { get; set; }
        public int id { get; set; } = 0;
        public List<Contratacion> ListaContrataciones { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            id = unaControladora.ProximoIdPago();
            ListaContrataciones = unaControladora.ListarContrataciones();
        }

        public IActionResult OnPostAgregar()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID del Pago");
                }
                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID del Pago debe ser un numero");
                }
                if (Request.Form["contratacion"] == "")
                {
                    throw new Exception("Debe seleccionar una Contratacion");
                }
                if (Request.Form["monto"] == "")
                {
                    throw new Exception("Debe ingresar el Monto");
                }
                if (!double.TryParse(Request.Form["monto"], out _))
                {
                    throw new Exception("El Monto debe ser un numero");
                }
                if (Request.Form["metodo"] == "")
                {
                    throw new Exception("Debe seleccionar un Metodo de Pago");
                }

                int Id = int.Parse(Request.Form["id"]);
                int ContratacionId = int.Parse(Request.Form["contratacion"]);
                DateTime FechaPago = DateTime.Now;
                double Monto = double.Parse(Request.Form["monto"]);
                string MetodoPago = Request.Form["metodo"];
                string Observacion = Request.Form["observacion"];

                Pago unPago = new Pago(Id, ContratacionId, FechaPago, Monto, MetodoPago, Observacion);

                Controladora unaControladora = new Controladora();

                unaControladora.AltaPago(unPago);

                return Redirect("/PagePago/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
    }
}