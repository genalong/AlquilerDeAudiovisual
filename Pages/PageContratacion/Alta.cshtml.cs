using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageContratacion
{
    public class AltaModel : PageModel
    {
        public string Mensaje { get; set; }

        public List<Solicitud> ListaSolicitudes { get; set; } = new List<Solicitud>();

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();

            foreach (Solicitud unaSolicitud in unaControladora.ListarSolicitudes())
            {
                if (unaSolicitud.Estado == "Aceptada")
                {
                    ListaSolicitudes.Add(unaSolicitud);
                }
            }
        }

        public IActionResult OnPostAgregar()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID de la Contratación");
                }

                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID debe ser un numero");
                }

                if (Request.Form["idSolicitud"] == "")
                {
                    throw new Exception("Debe seleccionar una Solicitud");
                }

                if (!int.TryParse(Request.Form["idSolicitud"], out _))
                {
                    throw new Exception("El ID de la Solicitud debe ser un numero");
                }

                if (Request.Form["fecha"] == "")
                {
                    throw new Exception("Debe ingresar la Fecha de Contratación");
                }

                if (Request.Form["estado"] == "")
                {
                    throw new Exception("Debe ingresar el Estado");
                }

                int Id = int.Parse(Request.Form["id"]);
                int IdSolicitud = int.Parse(Request.Form["idSolicitud"]);
                DateTime Fecha = DateTime.Parse(Request.Form["fecha"]);
                string Estado = Request.Form["estado"];

                Controladora unaControladora = new Controladora();

                Solicitud unaSolicitud = unaControladora.BuscarSolicitud(IdSolicitud);

                if (unaSolicitud == null || unaSolicitud.Estado != "Aceptada")
                {
                    throw new Exception("La Solicitud no existe o no esta aceptada");
                }

                if (unaControladora.BuscarContratacion(Id) != null)
                {
                    throw new Exception("Ya existe una Contratación con ese ID");
                }

                foreach (Contratacion unaContratacionExistente in unaControladora.ListarContrataciones())
                {
                    if (unaContratacionExistente.IdSolicitud == IdSolicitud)
                    {
                        throw new Exception("Esta Solicitud ya tiene una Contratación");
                    }
                }

                List<DetalleSolicitud> ListaDetalles =
                    unaControladora.ListarDetallesSolicitud(unaSolicitud);

                if (ListaDetalles.Count == 0)
                {
                    throw new Exception("La Solicitud no tiene detalles registrados");
                }

                Contratacion nuevaContratacion = new Contratacion(
                    Id,
                    Fecha,
                    0,
                    Estado
                );

                nuevaContratacion.IdSolicitud = IdSolicitud;

                bool SeAgrego = unaControladora.AltaContratacion(nuevaContratacion);

                if (!SeAgrego)
                {
                    throw new Exception("No se pudo registrar la Contratación");
                }

                bool SeGeneraron = unaControladora.GenerarDetallesContratacion(
                    unaSolicitud,
                    nuevaContratacion
                );

                if (!SeGeneraron)
                {
                    unaControladora.BajaContratacion(Id);

                    throw new Exception("No se pudieron generar los detalles de la Contratación");
                }

                return Redirect("/PageContratacion/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;

                Controladora unaControladora = new Controladora();

                foreach (Solicitud unaSolicitud in unaControladora.ListarSolicitudes())
                {
                    if (unaSolicitud.Estado == "Aceptada")
                    {
                        ListaSolicitudes.Add(unaSolicitud);
                    }
                }

                return Page();
            }
        }
    }
}