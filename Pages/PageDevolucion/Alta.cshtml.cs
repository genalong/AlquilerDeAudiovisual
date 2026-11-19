using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PageDevolucion
{
    public class AltaModel : PageModel
    {
        public string Mensaje { get; set; }
        public int id { get; set; } = 0;
        public List<Contratacion> ListaContrataciones { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            id = unaControladora.ProximoIdDevolucion();
            ListaContrataciones = unaControladora.ListarContrataciones();
        }

        public IActionResult OnPostAgregar()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID de la Devolucion");
                }
                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID de la Devolucion debe ser un numero");
                }
                if (Request.Form["contratacion"] == "")
                {
                    throw new Exception("Debe seleccionar una Contratacion");
                }
                if (Request.Form["fecha"] == "")
                {
                    throw new Exception("Debe ingresar la Fecha de Devolucion");
                }
                if (Request.Form["cargo"] == "")
                {
                    throw new Exception("Debe ingresar el Cargo Adicional");
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

                Devolucion unaDevolucion = new Devolucion(Id, ContratacionId, FechaDevolucion,
                    CargoAdicionalTotal, Observaciones);

                Controladora unaControladora = new Controladora();

                unaControladora.AltaDevolucion(unaDevolucion);

                return Redirect("/PageDevolucion/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
    }
}