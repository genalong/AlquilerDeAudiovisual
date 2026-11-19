using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

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
            lineas = unaControladora.ListarLineasContratacion(id);
            ListaEquipamientos = unaControladora.ListarEquipamientos();
            ListaPagos = unaControladora.ListarPagosPorContratacion(id);

            double TotalPagado = 0;

            foreach (Pago unPago in ListaPagos)
            {
                TotalPagado = TotalPagado + unPago.Monto;
            }

            SaldoPendiente = contratacion.ImporteTotal - TotalPagado;
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