using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageContratacion
{
    public class DetalleModel : PageModel
    {
        public Contratacion contratacion { get; set; }
        public List<LineaContratacion> lineas { get; set; }
        public List<Equipamiento> ListaEquipamientos { get; set; }
        public List<Pago> ListaPagos { get; set; }
        public double SaldoPendiente { get; set; }

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            contratacion = unaControladora.BuscarContratacion(id);
            lineas = unaControladora.ListarDetallesContratacion(id);
            ListaEquipamientos = unaControladora.ListarEquipamientos();
            ListaPagos = unaControladora.ListarPagosPorContratacion(id);
            SaldoPendiente = unaControladora.SaldoPendiente(id);
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