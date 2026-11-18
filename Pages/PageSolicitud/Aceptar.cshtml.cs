using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            lineas = unaControladora.ListarDetallesSolicitud(id);
            ListaEquipamientos = unaControladora.ListarEquipamientos();
        }

        public IActionResult OnPostAceptar()
        {
            try
            {
                int Id = int.Parse(Request.Form["id"]);

                Controladora unaControladora = new Controladora();

                int resultado = unaControladora.AceptarSolicitud(Id);

                if (resultado == -1)
                {
                    throw new Exception("No hay disponibilidad suficiente de equipamiento para esa fecha");
                }

                if (resultado == -2)
                {
                    throw new Exception("La solicitud no existe o no está en estado Pendiente");
                }

                if (resultado == -3)
                {
                    throw new Exception("Error al crear la contratación");
                }

                return Redirect("/PageSolicitud/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;

                int Id = int.Parse(Request.Form["id"]);
                Controladora unaControladora = new Controladora();
                solicitud = unaControladora.BuscarSolicitud(Id);
                lineas = unaControladora.ListarDetallesSolicitud(Id);
                ListaEquipamientos = unaControladora.ListarEquipamientos();

                return Page();
            }
        }

        public string NombreEquipamiento(int pEquipamientoId)
        {
            if (ListaEquipamientos == null)
            {
                return "(desconocido)";
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