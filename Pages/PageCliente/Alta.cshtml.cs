using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Pages.PageCliente
{
    public class AltaModel : PageModel
    {
        public string Mensaje { get; set; }
        public int id { get; set; } = 0;

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();
            id = unaControladora.ProximoIdCliente();
        }

        public IActionResult OnPostAgregar()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID del Cliente");
                }
                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID del Cliente debe ser un numero");
                }
                if (Request.Form["nombre"] == "")
                {
                    throw new Exception("Debe ingresar el Nombre del Cliente");
                }
                if (Request.Form["tipo"] == "")
                {
                    throw new Exception("Debe ingresar el Tipo del Cliente");
                }
                if (Request.Form["documento"] == "")
                {
                    throw new Exception("Debe ingresar el Documento del Cliente");
                }
                if (Request.Form["telefono"] == "")
                {
                    throw new Exception("Debe ingresar el Telefono del Cliente");
                }
                if (Request.Form["email"] == "")
                {
                    throw new Exception("Debe ingresar el Email del Cliente");
                }
                if (Request.Form["direccion"] == "")
                {
                    throw new Exception("Debe ingresar la Direccion del Cliente");
                }

                int Id = int.Parse(Request.Form["id"]);
                string Nombre = Request.Form["nombre"];
                string Tipo = Request.Form["tipo"];
                string Documento = Request.Form["documento"];
                string Email = Request.Form["email"];
                string Telefono = Request.Form["telefono"];
                string Direccion = Request.Form["direccion"];

                Cliente unCliente = new Cliente(Id, Nombre, Tipo, Documento, Email, Telefono, Direccion, true);

                Controladora unaControladora = new Controladora();

                unaControladora.AltaCliente(unCliente);

                return Redirect("/PageCliente/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
    }
}