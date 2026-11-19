using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PageSolicitud
{
    public class AltaModel : PageModel
    {
        public string Mensaje { get; set; }
        public int id { get; set; } = 0;
        public SolicitudAlquiler SolicitudEnCurso { get; set; }
        public List<LineaSolicitud> LineasEnCurso { get; set; }
        public List<Cliente> ListaClientes { get; set; }
        public List<Equipamiento> ListaEquipamientos { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            id = unaControladora.ProximoSolicitudId();
            ListaClientes = unaControladora.ListarClientes();
            ListaEquipamientos = unaControladora.ListarEquipamientos();
            SolicitudEnCurso = ObtenerSolicitudEnBorrador();

            if (SolicitudEnCurso != null)
                LineasEnCurso = unaControladora.ListarLineasSolicitud(SolicitudEnCurso.Id);
            else
                LineasEnCurso = new List<LineaSolicitud>();
        }

        public IActionResult OnPostAgregarSolicitud()
        {
            try
            {
                if (Request.Form["id"] == "")
                    throw new Exception("Debe ingresar el ID de la Solicitud");
                if (!int.TryParse(Request.Form["id"], out _))
                    throw new Exception("El ID debe ser un numero");
                if (Request.Form["cliente"] == "")
                    throw new Exception("Debe seleccionar un Cliente");
                if (Request.Form["tipoevento"] == "")
                    throw new Exception("Debe seleccionar un Tipo de Evento");
                if (Request.Form["fechainicio"] == "")
                    throw new Exception("Debe ingresar la Fecha de Inicio");
                if (Request.Form["fechafin"] == "")
                    throw new Exception("Debe ingresar la Fecha de Fin");
                if (Request.Form["ubicacion"] == "")
                    throw new Exception("Debe ingresar la Ubicacion");
                if (Request.Form["asistentes"] == "")
                    throw new Exception("Debe ingresar la Cantidad de Asistentes");

                int Id = int.Parse(Request.Form["id"]);
                int ClienteId = int.Parse(Request.Form["cliente"]);
                string TipoEvento = Request.Form["tipoevento"];
                string NombreEvento = Request.Form["nombreevento"];
                DateTime FechaInicio = DateTime.Parse(Request.Form["fechainicio"]);
                DateTime FechaFin = DateTime.Parse(Request.Form["fechafin"]);
                string Ubicacion = Request.Form["ubicacion"];
                int CantidadAsistentes = int.Parse(Request.Form["asistentes"]);

                if (FechaFin < FechaInicio)
                    throw new Exception("La Fecha de Fin no puede ser anterior a la Fecha de Inicio");

                SolicitudAlquiler unaSolicitud = new SolicitudAlquiler(Id, ClienteId, TipoEvento, NombreEvento,
                    FechaInicio, FechaFin, Ubicacion, CantidadAsistentes, "Borrador");

                Controladora unaControladora = new Controladora();
                unaControladora.AltaSolicitud(unaSolicitud);

                return Redirect("/PageSolicitud/Alta");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }

        public IActionResult OnPostAgregarLinea()
        {
            try
            {
                Controladora unaControladora = new Controladora();
                SolicitudAlquiler laSolicitud = ObtenerSolicitudEnBorrador();

                if (laSolicitud == null)
                    throw new Exception("Primero debe crear la solicitud con sus datos basicos");
                if (Request.Form["equipamiento"] == "" || Request.Form["equipamiento"] == "0")
                    throw new Exception("Debe seleccionar un Equipamiento");
                if (Request.Form["cantidad"] == "")
                    throw new Exception("Debe ingresar la Cantidad");

                int EquipamientoId = int.Parse(Request.Form["equipamiento"]);
                int Cantidad = int.Parse(Request.Form["cantidad"]);

                int NuevoId = unaControladora.ProximoIdLineaSolicitud();

                LineaSolicitud nuevaLinea = new LineaSolicitud(NuevoId, laSolicitud.Id, EquipamientoId, Cantidad);
                unaControladora.AltaLineaSolicitud(nuevaLinea);

                return Redirect("/PageSolicitud/Alta");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }

        public IActionResult OnPostQuitarLinea()
        {
            int LineaId = int.Parse(Request.Form["lineaid"]);
            Controladora unaControladora = new Controladora();
            unaControladora.BajaLineaSolicitud(LineaId);
            return Redirect("/PageSolicitud/Alta");
        }

        public IActionResult OnPostFinalizar()
        {
            try
            {
                Controladora unaControladora = new Controladora();
                SolicitudAlquiler laSolicitud = ObtenerSolicitudEnBorrador();

                if (laSolicitud == null)
                    throw new Exception("No hay solicitud en curso");

                List<LineaSolicitud> lineas = unaControladora.ListarLineasSolicitud(laSolicitud.Id);

                if (lineas.Count == 0)
                    throw new Exception("Debe agregar al menos un equipamiento a la solicitud");

                unaControladora.ModificarSolicitud(laSolicitud.Id, laSolicitud.ClienteId,
                    laSolicitud.TipoEvento, laSolicitud.NombreEvento, laSolicitud.FechaInicio,
                    laSolicitud.FechaFin, laSolicitud.Ubicacion, laSolicitud.CantidadAsistentes, "Pendiente");

                return Redirect("/PageSolicitud/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }

        private SolicitudAlquiler ObtenerSolicitudEnBorrador()
        {
            Controladora unaControladora = new Controladora();
            foreach (SolicitudAlquiler unaSolicitud in unaControladora.ListarSolicitudes())
                if (unaSolicitud.Estado == "Borrador") return unaSolicitud;
            return null;
        }

        public string NombreEquipamiento(int pEquipamientoId)
        {
            if (ListaEquipamientos == null)
            {
                Controladora unaControladora = new Controladora();
                ListaEquipamientos = unaControladora.ListarEquipamientos();
            }
            foreach (Equipamiento unEquipamiento in ListaEquipamientos)
                if (unEquipamiento.Id == pEquipamientoId) return unEquipamiento.Nombre;
            return "(desconocido)";
        }
    }
}