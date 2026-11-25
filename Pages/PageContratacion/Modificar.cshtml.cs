using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PageContratacion
{
    public class ModificarModel : PageModel
    {
        public Contratacion contratacion { get; set; }
        public List<Cliente> ListaClientes { get; set; }
        public List<Equipamiento> ListaEquipamientos { get; set; }
        public string Mensaje { get; set; } = "";

        public void OnGet(int id)
        {
            Controladora unaControladora = new Controladora();
            contratacion = unaControladora.BuscarContratacion(id);
            ListaClientes = unaControladora.ListarClientes();
            ListaEquipamientos = unaControladora.ListarEquipamientos();
        }

        public IActionResult OnPostModificar()
        {
            try
            {
                if (Request.Form["id"] == "")
                    throw new Exception("Debe ingresar el ID de la Contratacion");

                int Id = int.Parse(Request.Form["id"]);
                int ClienteId = int.Parse(Request.Form["cliente"]);
                int EquipamientoId = int.Parse(Request.Form["equipamiento"]);
                int Cantidad = int.Parse(Request.Form["cantidad"]);
                DateTime FechaInicio = DateTime.Parse(Request.Form["fechainicio"]);
                DateTime FechaFin = DateTime.Parse(Request.Form["fechafin"]);
                string Ubicacion = Request.Form["ubicacion"];
                double ImporteTotal = double.Parse(Request.Form["importetotal"]);
                string Estado = Request.Form["estado"];

                Controladora unaControladora = new Controladora();
                unaControladora.ModificarContratacion(Id, ClienteId, EquipamientoId, Cantidad, FechaInicio, FechaFin, Ubicacion, ImporteTotal, Estado);

                return Redirect("/PageContratacion/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
    }
}