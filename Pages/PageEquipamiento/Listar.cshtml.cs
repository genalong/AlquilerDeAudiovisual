using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageEquipamiento
{
    public class ListarModel : PageModel
    {
        public List<Equipamiento> ListaEquipamientos { get; set; }
        public List<Deposito> ListaDepositos { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();

            ListaEquipamientos = unaControladora.ListarEquipamientos();
            ListaDepositos = unaControladora.ListarDepositos();
        }

        public string NombreDeposito(int pDepositoId)
        {
            if (ListaDepositos == null)
            {
                return "(sin depósito)";
            }

            foreach (Deposito unDeposito in ListaDepositos)
            {
                if (unDeposito.Id == pDepositoId)
                {
                    return unDeposito.Nombre;
                }
            }

            return "(sin depósito)";
        }
    }
}