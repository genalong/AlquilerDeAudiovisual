using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PageReporte
{
    public class DetalleModel : PageModel
    {
        public Contratacion contratacion { get; set; }
        public List<Equipamiento> ListaEquipamientos { get; set; }

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            contratacion = unaControladora.BuscarContratacion(id);
            ListaEquipamientos = unaControladora.ListarEquipamientos();
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