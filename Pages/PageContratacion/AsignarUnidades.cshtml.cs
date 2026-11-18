using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            lineas = unaControladora.ListarDetallesContratacion(id);
            ListaEquipamientos = unaControladora.ListarEquipamientos();
        }

        public IActionResult OnPostAsignar()
        {
            try
            {
                int ContratacionId = int.Parse(Request.Form["contratacionid"]);

                Controladora unaControladora = new Controladora();

                Contratacion laContratacion = unaControladora.BuscarContratacion(ContratacionId);

                if (laContratacion != null)
                {
                    laContratacion.Estado = "Activa";
                    unaControladora.ModificarContratacion(laContratacion);     
                }

                return Redirect("/PageContratacion/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                int Id = int.Parse(Request.Form["contratacionid"]);
                Controladora unaControladora = new Controladora();
                contratacion = unaControladora.BuscarContratacion(Id);
                lineas = unaControladora.ListarDetallesContratacion(Id);
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