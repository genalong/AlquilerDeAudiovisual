using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageSolicitud
{
    public class ModificarModel : PageModel
    {
        public Solicitud UnaSolicitud { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Evento> Eventos { get; set; }
        public string Mensaje { get; set; } = "";

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            UnaSolicitud = unaControladora.BuscarSolicitud(id);
            Clientes = unaControladora.ListarClientes();
            Eventos = unaControladora.ListarEventos();
        }

        public IActionResult OnPostModificar()
        {
            try
            {
                if (Request.Form["id"] == "")
                    throw new Exception("No se encontró el ID de la Solicitud");

                if (Request.Form["cliente"] == "")
                    throw new Exception("Debe seleccionar un Cliente");

                if (Request.Form["evento"] == "")
                    throw new Exception("Debe seleccionar un Evento");

                if (Request.Form["fechaSolicitud"] == "")
                    throw new Exception("Debe ingresar la Fecha de Solicitud");

                if (Request.Form["fechaInicio"] == "")
                    throw new Exception("Debe ingresar la Fecha de Inicio");

                if (Request.Form["fechaFin"] == "")
                    throw new Exception("Debe ingresar la Fecha de Fin");

                if (Request.Form["estado"] == "")
                    throw new Exception("Debe ingresar el Estado");

                int Id = int.Parse(Request.Form["id"]);
                int IdCliente = int.Parse(Request.Form["cliente"]);
                int IdEvento = int.Parse(Request.Form["evento"]);

                DateTime FechaSolicitud = DateTime.Parse(Request.Form["fechaSolicitud"]);
                DateTime FechaInicio = DateTime.Parse(Request.Form["fechaInicio"]);
                DateTime FechaFin = DateTime.Parse(Request.Form["fechaFin"]);

                string Estado = Request.Form["estado"];

                if (FechaFin < FechaInicio)
                    throw new Exception("La Fecha de Fin no puede ser anterior a la Fecha de Inicio");

                Controladora unaControladora = new Controladora();

                Cliente unCliente = unaControladora.BuscarCliente(IdCliente);
                Evento unEvento = unaControladora.BuscarEvento(IdEvento);

                if (unCliente == null)
                    throw new Exception("El Cliente seleccionado no existe");

                if (unEvento == null)
                    throw new Exception("El Evento seleccionado no existe");

                if (!unaControladora.ModificarSolicitud(
                    Id, FechaSolicitud, FechaInicio, FechaFin,
                    Estado, unCliente, unEvento))
                {
                    throw new Exception("No se pudo modificar la Solicitud");
                }

                return Redirect("/PageSolicitud/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;

                Controladora unaControladora = new Controladora();
                UnaSolicitud = unaControladora.BuscarSolicitud(int.Parse(Request.Form["id"]));
                Clientes = unaControladora.ListarClientes();
                Eventos = unaControladora.ListarEventos();

                return Page();
            }
        }
    }
}