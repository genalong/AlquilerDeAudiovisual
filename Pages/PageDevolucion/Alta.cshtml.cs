
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageDevolucion
{
    public class AltaModel : PageModel
    {
        public string Mensaje { get; set; } = "";
        public List<Contratacion> Contrataciones { get; set; } = new List<Contratacion>();

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            Contrataciones = unaControladora.ListarContrataciones();
        }

        public IActionResult OnPostAgregar()
        {
            try
            {
                if (Request.Form["id"] == "")
                    throw new Exception("Debe ingresar el ID de la Devolución");

                if (!int.TryParse(Request.Form["id"], out int Id))
                    throw new Exception("El ID debe ser un número");

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

                DateTime Fecha = DateTime.Parse(Request.Form["fecha"]);
                string Modalidad = Request.Form["modalidad"];
                string LugarDevolucion = Request.Form["lugarDevolucion"];
                string Observaciones = Request.Form["observaciones"];

                Controladora unaControladora = new Controladora();

                Contratacion unaContratacion = unaControladora.BuscarContratacion(IdContratacion);

                if (unaContratacion == null)
                    throw new Exception("La Contratación seleccionada no existe");

                Devolucion unaDevolucion = new Devolucion(
                    Id, Fecha, Modalidad, LugarDevolucion,
                    Observaciones, unaContratacion
                );

                if (!unaControladora.AltaDevolucion(unaDevolucion))
                    throw new Exception("Ya existe una Devolución con ese ID");

                return RedirectToPage("./Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                OnGet();
                return Page();
            }
        }
    }
}
