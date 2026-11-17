using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageContratacion
{
    public class EliminarModel : PageModel
    {
        public int Id { get; set; }

        public string Mensaje { get; set; }

        public IActionResult OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            Contratacion unaContratacion = unaControladora.BuscarContratacion(id);

            if (unaContratacion != null)
            {
                Id = unaContratacion.Id;
                return Page();
            }

            return Redirect("/PageContratacion/Listar");
        }

        public IActionResult OnPostEliminar()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID de la Contratación");
                }

                int Id = int.Parse(Request.Form["id"]);

                Controladora unaControladora = new Controladora();

                Contratacion unaContratacion = unaControladora.BuscarContratacion(Id);

                if (unaContratacion == null)
                {
                    throw new Exception("No existe la Contratación");
                }

                List<DetalleContratacion> ListaDetalles =
                    new List<DetalleContratacion>(
                        unaControladora.ListarDetallesContratacion()
                    );

                foreach (DetalleContratacion unDetalle in ListaDetalles)
                {
                    if (unDetalle.Contratacion != null &&
                        unDetalle.Contratacion.Id == Id)
                    {
                        unaControladora.BajaDetalleContratacion(unDetalle.Id);
                    }
                }

                bool SeElimino = unaControladora.BajaContratacion(Id);

                if (!SeElimino)
                {
                    throw new Exception("No se pudo eliminar la Contratación");
                }

                return Redirect("/PageContratacion/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;

                int IdBuscado;

                if (int.TryParse(Request.Form["id"], out IdBuscado))
                {
                    Id = IdBuscado;
                }

                return Page();
            }
        }
    }
}