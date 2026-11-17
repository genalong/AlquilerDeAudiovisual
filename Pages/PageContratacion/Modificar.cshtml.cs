using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageContratacion
{
    public class ModificarModel : PageModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string Estado { get; set; }

        public string Mensaje { get; set; }

        public IActionResult OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            Contratacion unaContratacion = unaControladora.BuscarContratacion(id);

            if (unaContratacion != null)
            {
                Id = unaContratacion.Id;
                Fecha = unaContratacion.Fecha;
                Total = unaContratacion.Total;
                Estado = unaContratacion.Estado;

                return Page();
            }

            return Redirect("/PageContratacion/Listar");
        }

        public IActionResult OnPostModificar()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID de la Contratación");
                }

                if (Request.Form["fecha"] == "")
                {
                    throw new Exception("Debe ingresar la Fecha");
                }

                if (Request.Form["estado"] == "")
                {
                    throw new Exception("Debe ingresar el Estado");
                }

                int Id = int.Parse(Request.Form["id"]);
                DateTime Fecha = DateTime.Parse(Request.Form["fecha"]);
                string Estado = Request.Form["estado"];

                Controladora unaControladora = new Controladora();

                Contratacion unaContratacion = unaControladora.BuscarContratacion(Id);

                if (unaContratacion == null)
                {
                    throw new Exception("No existe la Contratación");
                }

                bool SeModifico = unaControladora.ModificarContratacion(
                    Id,
                    Fecha,
                    unaContratacion.Total,
                    Estado
                );

                if (!SeModifico)
                {
                    throw new Exception("No se pudo modificar la Contratación");
                }

                return Redirect("/PageContratacion/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;

                int IdBuscado;

                if (int.TryParse(Request.Form["id"], out IdBuscado))
                {
                    Controladora unaControladora = new Controladora();

                    Contratacion unaContratacion = unaControladora.BuscarContratacion(IdBuscado);

                    if (unaContratacion != null)
                    {
                        this.Id = unaContratacion.Id;
                        Fecha = unaContratacion.Fecha;
                        Total = unaContratacion.Total;
                        Estado = unaContratacion.Estado;
                    }
                }

                return Page();
            }
        }
    }
}