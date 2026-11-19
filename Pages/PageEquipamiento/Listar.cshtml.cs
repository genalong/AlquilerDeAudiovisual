using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PageEquipamiento
{
    public class ListarModel : PageModel
    {
        public List<Equipamiento> ListaEquipamientos { get; set; }
        public List<Deposito> ListaDepositos { get; set; }
        public List<Contratacion> ListaContrataciones { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            ListaEquipamientos = unaControladora.ListarEquipamientos();
            ListaDepositos = unaControladora.ListarDepositos();
            ListaContrataciones = unaControladora.ListarContrataciones();
        }

        public string NombreDeposito(int pDepositoId)
        {
            if (ListaDepositos == null) return "(sin deposito)";
            foreach (Deposito unDeposito in ListaDepositos)
                if (unDeposito.Id == pDepositoId) return unDeposito.Nombre;
            return "(sin deposito)";
        }

        public int CalcularDisponible(int pEquipamientoId)
        {
            Equipamiento elEquipamiento = null;
            foreach (Equipamiento e in ListaEquipamientos)
                if (e.Id == pEquipamientoId) { elEquipamiento = e; break; }
            if (elEquipamiento == null) return 0;

            Controladora unaControladora = new Controladora();
            int comprometido = 0;

            foreach (Contratacion c in ListaContrataciones)
            {
                if (c.Estado == "Cancelada" || c.Estado == "Finalizada") continue;
                if (c.FechaFin.Date < DateTime.Now.Date || c.FechaInicio.Date > DateTime.Now.Date) continue;

                List<LineaContratacion> lineas = unaControladora.ListarLineasContratacion(c.Id);
                foreach (LineaContratacion l in lineas)
                    if (l.EquipamientoId == pEquipamientoId) comprometido += l.Cantidad;
            }

            int enMantenimiento = elEquipamiento.Estado == "En mantenimiento" ? elEquipamiento.Stock : 0;
            return elEquipamiento.Stock - enMantenimiento - comprometido;
        }
    }
}