using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PageContratacion
{
    public class AsignarUnidadesModel : PageModel
    {
        public Contratacion contratacion { get; set; }
        public List<LineaContratacion> lineas { get; set; }
        public List<Equipamiento> ListaEquipamientos { get; set; }
        public string Mensaje { get; set; }

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            contratacion = unaControladora.BuscarContratacion(id);
            lineas = unaControladora.ListarLineasContratacion(id);
            ListaEquipamientos = unaControladora.ListarEquipamientos();
        }

        public IActionResult OnPostAsignar()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID de la Contratacion");
                }
                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID de la Contratacion debe ser un numero");
                }

                int Id = int.Parse(Request.Form["id"]);

                Controladora unaControladora = new Controladora();

                Contratacion laContratacion = unaControladora.BuscarContratacion(Id);

                if (laContratacion == null)
                {
                    throw new Exception("La contratacion no existe");
                }

                unaControladora.ModificarContratacion(
                    laContratacion.Id,
                    laContratacion.FechaInicio,
                    laContratacion.FechaFin,
                    laContratacion.Ubicacion,
                    laContratacion.ImporteTotal,
                    "Activa");

                return Redirect("/PageContratacion/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;

                int Id = int.Parse(Request.Form["id"]);
                Controladora unaControladora = new Controladora();
                contratacion = unaControladora.BuscarContratacion(Id);
                lineas = unaControladora.ListarLineasContratacion(Id);
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