
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageDevolucion
{
    public class ModificarModel : PageModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Modalidad { get; set; } = "";
        public string LugarDevolucion { get; set; } = "";
        public string Observaciones { get; set; } = "";
        public int IdContratacion { get; set; }
        public List<Contratacion> Contrataciones { get; set; } = new List<Contratacion>();
        public string Mensaje { get; set; } = "";

        public IActionResult OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            Contrataciones = unaControladora.ListarContrataciones();

            Devolucion unaDevolucion = unaControladora.BuscarDevolucion(id);

            if (unaDevolucion != null)
            {
                Id = unaDevolucion.Id;
                Fecha = unaDevolucion.Fecha;
                Modalidad = unaDevolucion.Modalidad;
                LugarDevolucion = unaDevolucion.LugarDevolucion;
                Observaciones = unaDevolucion.Observaciones;
                IdContratacion = unaDevolucion.Contratacion.Id;

                return Page();
            }

            return RedirectToPage("./Listar");
        }

        public IActionResult OnPostModificar()
        {
            try
            {
                if (Request.Form["id"] == "")
                    throw new Exception("Debe ingresar el ID");

                if (Request.Form["fecha"] == "")
                    throw new Exception("Debe ingresar la Fecha");

                if (Request.Form["modalidad"] == "")
                    throw new Exception("Debe ingresar la Modalidad");

                if (Request.Form["lugarDevolucion"] == "")
                    throw new Exception("Debe ingresar el Lugar de devolución");

                if (Request.Form["observaciones"] == "")
                    throw new Exception("Debe ingresar las Observaciones");

                if (!int.TryParse(Request.Form["contratacion"], out int IdContratacion))
                    throw new Exception("Debe seleccionar una Contratación");

                int Id = int.Parse(Request.Form["id"]);
                DateTime Fecha = DateTime.Parse(Request.Form["fecha"]);
                string Modalidad = Request.Form["modalidad"];
                string LugarDevolucion = Request.Form["lugarDevolucion"];
                string Observaciones = Request.Form["observaciones"];

                Controladora unaControladora = new Controladora();

                Contratacion unaContratacion =
                    unaControladora.BuscarContratacion(IdContratacion);

                if (unaContratacion == null)
                    throw new Exception("La Contratación no existe");

                if (!unaControladora.ModificarDevolucion(
                    Id, Fecha, Modalidad, LugarDevolucion,
                    Observaciones, unaContratacion))
                {
                    throw new Exception("No se pudo modificar la Devolución");
                }

                return RedirectToPage("./Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                Contrataciones = new Controladora().ListarContrataciones();
                return Page();
            }
        }
    }
}
