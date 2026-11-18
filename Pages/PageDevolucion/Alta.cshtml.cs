using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageDevolucion
{
    public class AltaModel : PageModel
    {
        public string Mensaje { get; set; }
        public List<Contratacion> ListaContrataciones { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            ListaContrataciones = unaControladora.ListarContrataciones();
        }

        public IActionResult OnPostAgregar()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID de la Devolución");
                }

                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID debe ser un numero");
                }

                if (Request.Form["contratacion"] == "")
                {
                    throw new Exception("Debe seleccionar una Contratación");
                }

                if (Request.Form["fecha"] == "")
                {
                    throw new Exception("Debe ingresar la Fecha de Devolución");
                }

                if (Request.Form["cargo"] == "")
                {
                    throw new Exception("Debe ingresar el Cargo Adicional (puede ser 0)");
                }

                if (!double.TryParse(Request.Form["cargo"], out _))
                {
                    throw new Exception("El Cargo Adicional debe ser un numero");
                }

                int Id = int.Parse(Request.Form["id"]);
                int ContratacionId = int.Parse(Request.Form["contratacion"]);
                DateTime FechaDevolucion = DateTime.Parse(Request.Form["fecha"]);
                double CargoAdicionalTotal = double.Parse(Request.Form["cargo"]);
                string Observaciones = Request.Form["observaciones"];

                Devolucion unaDevolucion = new Devolucion(
                    Id, ContratacionId, FechaDevolucion, CargoAdicionalTotal, Observaciones);

                Controladora unaControladora = new Controladora();

                if (!unaControladora.AltaDevolucion(unaDevolucion))
                {
                    throw new Exception("Ya existe una devolución con ese ID");
                }

                return Redirect("/PageDevolucion/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                Controladora unaControladora = new Controladora();
                ListaContrataciones = unaControladora.ListarContrataciones();
                return Page();
            }
        }
    }
}