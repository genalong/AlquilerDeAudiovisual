using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PageContratacion
{
    public class AltaModel : PageModel
    {
        public string Mensaje { get; set; }
        public int id { get; set; } = 0;
        public List<Cliente> ListaClientes { get; set; }
        public List<Equipamiento> ListaEquipamientos { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            id = unaControladora.ProximoIdContratacion();
            ListaClientes = unaControladora.ListarClientes();
            ListaEquipamientos = unaControladora.ListarEquipamientos();
        }

        public IActionResult OnPostAgregar()
        {
            try
            {
                if (Request.Form["id"] == "")
                    throw new Exception("Debe ingresar el ID de la Contratacion");
                if (!int.TryParse(Request.Form["id"], out _))
                    throw new Exception("El ID debe ser un numero");
                if (Request.Form["cliente"] == "")
                    throw new Exception("Debe seleccionar un Cliente");
                if (Request.Form["equipamiento"] == "")
                    throw new Exception("Debe seleccionar un Equipamiento");
                if (Request.Form["cantidad"] == "")
                    throw new Exception("Debe ingresar la Cantidad");
                if (Request.Form["fechainicio"] == "")
                    throw new Exception("Debe ingresar la Fecha de Inicio");
                if (Request.Form["fechafin"] == "")
                    throw new Exception("Debe ingresar la Fecha de Fin");
                if (Request.Form["ubicacion"] == "")
                    throw new Exception("Debe ingresar la Ubicacion");
                if (Request.Form["estado"] == "")
                    throw new Exception("Debe seleccionar un Estado");

                int Id = int.Parse(Request.Form["id"]);
                int ClienteId = int.Parse(Request.Form["cliente"]);
                int EquipamientoId = int.Parse(Request.Form["equipamiento"]);
                int Cantidad = int.Parse(Request.Form["cantidad"]);
                DateTime FechaInicio = DateTime.Parse(Request.Form["fechainicio"]);
                DateTime FechaFin = DateTime.Parse(Request.Form["fechafin"]);
                string Ubicacion = Request.Form["ubicacion"];
                double ImporteTotal = double.Parse(Request.Form["importetotal"]);
                string Estado = Request.Form["estado"];

                if (FechaFin < FechaInicio)
                    throw new Exception("La Fecha de Fin no puede ser anterior a la Fecha de Inicio");

                Contratacion unaContratacion = new Contratacion(Id, ClienteId, EquipamientoId, Cantidad,
                    FechaInicio, FechaFin, Ubicacion, ImporteTotal, Estado);

                Controladora unaControladora = new Controladora();
                unaControladora.AltaContratacion(unaContratacion);

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