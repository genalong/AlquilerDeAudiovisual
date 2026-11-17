using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageRecepcionDevolucion
{
    public class AltaModel : PageModel
    {
        public List<Devolucion> Devoluciones { get; set; } = new List<Devolucion>();

        public List<DetalleContratacion> DetallesContratacion { get; set; } = new List<DetalleContratacion>();

        public int IdDevolucionSeleccionada { get; set; }

        public string Mensaje { get; set; } = "";

        public void OnGet(int? idDevolucion)
        {
            Controladora unaControladora = new Controladora();

            Devoluciones = unaControladora.ListarDevoluciones();

            if (idDevolucion.HasValue)
            {
                IdDevolucionSeleccionada = idDevolucion.Value;

                Devolucion unaDevolucion =
                    unaControladora.BuscarDevolucion(IdDevolucionSeleccionada);

                if (unaDevolucion != null &&
                    unaDevolucion.Contratacion != null)
                {
                    foreach (DetalleContratacion unDetalle in
                        unaControladora.ListarDetallesContratacion())
                    {
                        if (unDetalle.Contratacion != null &&
                            unDetalle.Contratacion.Id ==
                            unaDevolucion.Contratacion.Id)
                        {
                            DetallesContratacion.Add(unDetalle);
                        }
                    }
                }
            }
        }

        public IActionResult OnPostAgregar()
        {
            int IdDevolucion = 0;

            int.TryParse(Request.Form["idDevolucion"].ToString(),
                out IdDevolucion);

            try
            {
                if (!int.TryParse(Request.Form["id"].ToString(),
                    out int Id))
                {
                    throw new Exception("El ID debe ser un número");
                }

                string EstadoRecepcion =
                    Request.Form["estadoRecepcion"].ToString();

                if (EstadoRecepcion == "")
                {
                    throw new Exception("Debe ingresar el estado de recepción");
                }

                if (!int.TryParse(
                    Request.Form["detalleContratacion"].ToString(),
                    out int IdDetalleContratacion))
                {
                    throw new Exception("Debe seleccionar el equipamiento");
                }

                string Observaciones =
                    Request.Form["observaciones"].ToString();

                Controladora unaControladora = new Controladora();

                Devolucion unaDevolucion =
                    unaControladora.BuscarDevolucion(IdDevolucion);

                if (unaDevolucion == null ||
                    unaDevolucion.Contratacion == null)
                {
                    throw new Exception(
                        "La devolución seleccionada no existe o no tiene contratación");
                }

                DetalleContratacion unDetalleContratacion =
                    unaControladora.BuscarDetalleContratacion(
                        IdDetalleContratacion);

                if (unDetalleContratacion == null ||
                    unDetalleContratacion.Contratacion == null ||
                    unDetalleContratacion.Contratacion.Id !=
                    unaDevolucion.Contratacion.Id)
                {
                    throw new Exception(
                        "El equipamiento no pertenece a la contratación de esta devolución");
                }

                DetalleDevolucion unDetalleDevolucion =
                    new DetalleDevolucion(
                        Id,
                        EstadoRecepcion,
                        Observaciones,
                        unaDevolucion,
                        unDetalleContratacion
                    );

                if (!unaControladora.AltaDetalleDevolucion(
                    unDetalleDevolucion))
                {
                    throw new Exception(
                        "Ya existe un detalle de devolución con ese ID");
                }

                return RedirectToPage("./Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;

                OnGet(IdDevolucion);

                return Page();
            }
        }
    }
}