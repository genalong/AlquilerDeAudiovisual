using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PageSolicitud
{
    public class AceptarModel : PageModel
    {
        public SolicitudAlquiler solicitud { get; set; }
        public List<LineaSolicitud> lineas { get; set; }
        public List<Equipamiento> ListaEquipamientos { get; set; }
        public string Mensaje { get; set; }

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            solicitud = unaControladora.BuscarSolicitud(id);
            lineas = unaControladora.ListarLineasSolicitud(id);
            ListaEquipamientos = unaControladora.ListarEquipamientos();
        }

        public IActionResult OnPostAceptar()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID de la Solicitud");
                }
                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID de la Solicitud debe ser un numero");
                }

                int Id = int.Parse(Request.Form["id"]);

                Controladora unaControladora = new Controladora();

                SolicitudAlquiler laSolicitud = unaControladora.BuscarSolicitud(Id);

                if (laSolicitud == null)
                {
                    throw new Exception("La solicitud no existe");
                }

                if (laSolicitud.Estado != "Pendiente")
                {
                    throw new Exception("La solicitud no esta en estado Pendiente");
                }

                List<LineaSolicitud> detalles = unaControladora.ListarLineasSolicitud(Id);

                if (detalles.Count == 0)
                {
                    throw new Exception("La solicitud no tiene equipamientos cargados");
                }

                foreach (LineaSolicitud unaLinea in detalles)
                {
                    Equipamiento elEquipamiento = unaControladora.BuscarEquipamiento(unaLinea.EquipamientoId);

                    if (elEquipamiento == null)
                    {
                        throw new Exception("Equipamiento no encontrado");
                    }

                    int comprometido = 0;

                    foreach (Contratacion unaContratacion in unaControladora.ListarContrataciones())
                    {
                        if (unaContratacion.Estado == "Cancelada" || unaContratacion.Estado == "Finalizada")
                        {
                            continue;
                        }

                        if (unaContratacion.FechaFin.Date < laSolicitud.FechaInicio.Date ||
                            unaContratacion.FechaInicio.Date > laSolicitud.FechaFin.Date)
                        {
                            continue;
                        }

                        foreach (LineaContratacion unaLineaContratacion in unaControladora.ListarLineasContratacion(unaContratacion.Id))
                        {
                            if (unaLineaContratacion.EquipamientoId == unaLinea.EquipamientoId)
                            {
                                comprometido = comprometido + unaLineaContratacion.Cantidad;
                            }
                        }
                    }

                    int enMantenimiento = 0;
                    if (elEquipamiento.Estado == "En mantenimiento")
                    {
                        enMantenimiento = elEquipamiento.Stock;
                    }

                    int disponible = elEquipamiento.Stock - enMantenimiento - comprometido;

                    if (disponible < unaLinea.Cantidad)
                    {
                        throw new Exception("No hay disponibilidad suficiente de " + elEquipamiento.Nombre);
                    }
                }

                int NuevoIdContratacion = unaControladora.ProximoIdContratacion();

                Contratacion laContratacion = new Contratacion(
                    NuevoIdContratacion,
                    laSolicitud.Id,
                    laSolicitud.ClienteId,
                    laSolicitud.FechaInicio,
                    laSolicitud.FechaFin,
                    laSolicitud.Ubicacion,
                    0,
                    "En preparación");

                unaControladora.AltaContratacion(laContratacion);

                double Total = 0;

                foreach (LineaSolicitud unaLinea in detalles)
                {
                    Equipamiento elEquipamiento = unaControladora.BuscarEquipamiento(unaLinea.EquipamientoId);
                    double PrecioUnitario = 0;

                    if (elEquipamiento != null)
                    {
                        PrecioUnitario = elEquipamiento.PrecioBaseAlquiler;
                    }

                    int NuevoIdLinea = unaControladora.ProximoIdLineaContratacion();

                    LineaContratacion nuevaLinea = new LineaContratacion(
                        NuevoIdLinea,
                        laContratacion.Id,
                        unaLinea.EquipamientoId,
                        unaLinea.Cantidad,
                        PrecioUnitario);

                    unaControladora.AltaLineaContratacion(nuevaLinea);

                    Total = Total + (unaLinea.Cantidad * PrecioUnitario);
                }

                unaControladora.ModificarContratacion(
                    laContratacion.Id,
                    laContratacion.FechaInicio,
                    laContratacion.FechaFin,
                    laContratacion.Ubicacion,
                    Total,
                    laContratacion.Estado);

                unaControladora.ModificarSolicitud(
                    laSolicitud.Id,
                    laSolicitud.ClienteId,
                    laSolicitud.TipoEvento,
                    laSolicitud.NombreEvento,
                    laSolicitud.FechaInicio,
                    laSolicitud.FechaFin,
                    laSolicitud.Ubicacion,
                    laSolicitud.CantidadAsistentes,
                    "Aceptada");

                return Redirect("/PageSolicitud/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;

                int Id = int.Parse(Request.Form["id"]);
                Controladora unaControladora = new Controladora();
                solicitud = unaControladora.BuscarSolicitud(Id);
                lineas = unaControladora.ListarLineasSolicitud(Id);
                ListaEquipamientos = unaControladora.ListarEquipamientos();

                return Page();
            }
        }

        public string NombreEquipamiento(int pEquipamientoId)
        {
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