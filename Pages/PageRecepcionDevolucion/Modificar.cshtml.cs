using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageRecepcionDevolucion
{
    public class ModificarModel : PageModel
    {
        public int Id { get; set; }

        public string EstadoRecepcion { get; set; } = "";

        public string Observaciones { get; set; } = "";

        public string Mensaje { get; set; } = "";

        public IActionResult OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            DetalleDevolucion unDetalle =
                unaControladora.BuscarDetalleDevolucion(id);

            if (unDetalle == null)
            {
                return RedirectToPage("./Listar");
            }

            Id = unDetalle.Id;
            EstadoRecepcion = unDetalle.EstadoRecepcion;
            Observaciones = unDetalle.Observaciones;

            return Page();
        }

        public IActionResult OnPostModificar()
        {
            try
            {
                if (!int.TryParse(Request.Form["id"].ToString(),
                    out int IdDetalle))
                {
                    throw new Exception("El ID no es válido");
                }

                string Estado =
                    Request.Form["estadoRecepcion"].ToString();

                if (Estado == "")
                {
                    throw new Exception(
                        "Debe ingresar el estado de recepción");
                }

                string Observacion =
                    Request.Form["observaciones"].ToString();

                Controladora unaControladora = new Controladora();

                if (!unaControladora.ModificarDetalleDevolucion(
                    IdDetalle, Estado, Observacion))
                {
                    throw new Exception(
                        "No se pudo modificar el detalle de recepción");
                }

                return RedirectToPage("./Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;

                int.TryParse(Request.Form["id"].ToString(), out int IdTemporal);
                Id = IdTemporal;

                EstadoRecepcion =
                    Request.Form["estadoRecepcion"].ToString();

                Observaciones =
                    Request.Form["observaciones"].ToString();

                return Page();
            }
        }
    }
}