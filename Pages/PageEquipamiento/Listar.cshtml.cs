using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

            int comprometido = 0;
            foreach (Contratacion c in ListaContrataciones)
            {
                if (c.Estado == "Aprobado" && c.EquipamientoId == pEquipamientoId)
                {
                    comprometido += c.Cantidad;
                }
            }

            return elEquipamiento.Stock - comprometido;
        }
    }
}