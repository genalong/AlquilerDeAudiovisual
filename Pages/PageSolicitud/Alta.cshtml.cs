using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AlquilerAudiovisual.Pages.PageSolicitud
{
    public class AltaModel : PageModel
    {
        public string Mensaje { get; set; }
        public SolicitudAlquiler SolicitudEnCurso { get; set; }
        public List<LineaSolicitud> LineasEnCurso { get; set; }
        public List<Cliente> ListaClientes { get; set; }
        public List<Equipamiento> ListaEquipamientos { get; set; }

        public void OnGet()
        {
            CargarListas();
            CargarSolicitudEnCurso();
        }

        public IActionResult OnPostAgregarSolicitud()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID de la Solicitud");
                }

                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID debe ser un numero");
                }

                if (Request.Form["cliente"] == "")
                {
                    throw new Exception("Debe seleccionar un Cliente");
                }

                if (Request.Form["nombreevento"] == "")
                {
                    throw new Exception("Debe ingresar el Nombre del Evento");
                }

                if (Request.Form["fecha"] == "")
                {
                    throw new Exception("Debe ingresar la Fecha del Evento");
                }

                if (Request.Form["ubicacion"] == "")
                {
                    throw new Exception("Debe ingresar la Ubicación");
                }

                if (Request.Form["horainicio"] == "")
                {
                    throw new Exception("Debe ingresar la Hora de Inicio");
                }

                if (Request.Form["horafin"] == "")
                {
                    throw new Exception("Debe ingresar la Hora de Fin");
                }

                if (Request.Form["asistentes"] == "")
                {
                    throw new Exception("Debe ingresar la Cantidad de Asistentes");
                }

                int Id = int.Parse(Request.Form["id"]);
                int ClienteId = int.Parse(Request.Form["cliente"]);
                string NombreEvento = Request.Form["nombreevento"];
                DateTime FechaEvento = DateTime.Parse(Request.Form["fecha"]);
                string Ubicacion = Request.Form["ubicacion"];
                string HoraInicio = Request.Form["horainicio"];
                string HoraFin = Request.Form["horafin"];
                int CantidadAsistentes = int.Parse(Request.Form["asistentes"]);

                SolicitudAlquiler unaSolicitud = new SolicitudAlquiler(
                    Id, ClienteId, NombreEvento, FechaEvento, Ubicacion,
                    HoraInicio, HoraFin, CantidadAsistentes, "Borrador");

                Controladora unaControladora = new Controladora();

                if (!unaControladora.AltaSolicitud(unaSolicitud))
                {
                    throw new Exception("Ya existe una solicitud con ese ID");
                }

                return Redirect("/PageSolicitud/Alta");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                CargarListas();
                CargarSolicitudEnCurso();
                return Page();
            }
        }

        public IActionResult OnPostAgregarLinea()
        {
            try
            {
                Controladora unaControladora = new Controladora();

                SolicitudEnCurso = ObtenerSolicitudEnBorrador();

                if (SolicitudEnCurso == null)
                {
                    throw new Exception("Primero debe crear la solicitud con sus datos básicos");
                }

                if (Request.Form["equipamiento"] == "")
                {
                    throw new Exception("Debe seleccionar un Equipamiento");
                }

                if (Request.Form["cantidad"] == "")
                {
                    throw new Exception("Debe ingresar la Cantidad");
                }

                if (!int.TryParse(Request.Form["cantidad"], out _))
                {
                    throw new Exception("La Cantidad debe ser un numero entero");
                }

                int EquipamientoId = int.Parse(Request.Form["equipamiento"]);
                int Cantidad = int.Parse(Request.Form["cantidad"]);

                int NuevoId = 1;
                foreach (LineaSolicitud unaLinea in unaControladora.ListarDetallesSolicitud())
                {
                    if (unaLinea.Id >= NuevoId)
                    {
                        NuevoId = unaLinea.Id + 1;
                    }
                }

                LineaSolicitud nuevaLinea = new LineaSolicitud(
                    NuevoId, SolicitudEnCurso.Id, EquipamientoId, Cantidad);

                unaControladora.AltaDetalleSolicitud(nuevaLinea);

                return Redirect("/PageSolicitud/Alta");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                CargarListas();
                CargarSolicitudEnCurso();
                return Page();
            }
        }

        public IActionResult OnPostQuitarLinea()
        {
            int LineaId = int.Parse(Request.Form["lineaid"]);

            Controladora unaControladora = new Controladora();
            unaControladora.BajaDetalleSolicitud(LineaId);

            return Redirect("/PageSolicitud/Alta");
        }

        public IActionResult OnPostFinalizar()
        {
            try
            {
                Controladora unaControladora = new Controladora();

                SolicitudEnCurso = ObtenerSolicitudEnBorrador();

                if (SolicitudEnCurso == null)
                {
                    throw new Exception("No hay solicitud en curso");
                }

                List<LineaSolicitud> lineas = unaControladora.ListarDetallesSolicitud(SolicitudEnCurso.Id);

                if (lineas.Count == 0)
                {
                    throw new Exception("Debe agregar al menos un equipamiento a la solicitud");
                }

                SolicitudEnCurso.Estado = "Pendiente";
                unaControladora.ModificarSolicitud(SolicitudEnCurso);     

                return Redirect("/PageSolicitud/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                CargarListas();
                CargarSolicitudEnCurso();
                return Page();
            }
        }

        private void CargarListas()
        {
            Controladora unaControladora = new Controladora();

            ListaClientes = unaControladora.ListarClientes();
            ListaEquipamientos = unaControladora.ListarEquipamientos();
        }

        private void CargarSolicitudEnCurso()
        {
            Controladora unaControladora = new Controladora();

            SolicitudEnCurso = ObtenerSolicitudEnBorrador();

            if (SolicitudEnCurso != null)
            {
                LineasEnCurso = unaControladora.ListarDetallesSolicitud(SolicitudEnCurso.Id);
            }
            else
            {
                LineasEnCurso = new List<LineaSolicitud>();
            }
        }

        private SolicitudAlquiler ObtenerSolicitudEnBorrador()
        {
            Controladora unaControladora = new Controladora();

            foreach (SolicitudAlquiler unaSolicitud in unaControladora.ListarSolicitudes())
            {
                if (unaSolicitud.Estado == "Borrador")
                {
                    return unaSolicitud;
                }
            }

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
            {
                if (unEquipamiento.Id == pEquipamientoId)
                {
                    return unEquipamiento.Nombre;
                }
            }

            return "(desconocido)";
        }
    }
}