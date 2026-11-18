using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageEquipamiento
{
    public class AltaModel : PageModel
    {
        public string Mensaje { get; set; }
        public List<Deposito> ListaDepositos { get; set; }

        public void OnGet()
        {
            Controladora unaControladora = new Controladora();

            ListaDepositos = unaControladora.ListarDepositos();
        }

        public IActionResult OnPostAgregar()
        {
            try
            {
                if (Request.Form["id"] == "")
                {
                    throw new Exception("Debe ingresar el ID del Equipamiento");
                }

                if (!int.TryParse(Request.Form["id"], out _))
                {
                    throw new Exception("El ID del Equipamiento debe ser un numero");
                }

                if (Request.Form["nombre"] == "")
                {
                    throw new Exception("Debe ingresar el Nombre del Equipamiento");
                }

                if (Request.Form["marca"] == "")
                {
                    throw new Exception("Debe ingresar la Marca del Equipamiento");
                }

                if (Request.Form["modelo"] == "")
                {
                    throw new Exception("Debe ingresar el Modelo del Equipamiento");
                }

                if (Request.Form["deposito"] == "")
                {
                    throw new Exception("Debe seleccionar un Depósito");
                }

                if (Request.Form["precio"] == "")
                {
                    throw new Exception("Debe ingresar el Precio Base de Alquiler");
                }

                if (!double.TryParse(Request.Form["precio"], out _))
                {
                    throw new Exception("El Precio debe ser un numero");
                }

                if (Request.Form["codigo"] == "")
                {
                    throw new Exception("Debe ingresar el Código del Equipamiento");
                }

                if (Request.Form["estado"] == "")
                {
                    throw new Exception("Debe seleccionar un Estado");
                }

                if (Request.Form["stock"] == "")
                {
                    throw new Exception("Debe ingresar el Stock del Equipamiento");
                }

                if (!int.TryParse(Request.Form["stock"], out _))
                {
                    throw new Exception("El Stock debe ser un numero entero");
                }

                int Id = int.Parse(Request.Form["id"]);
                string Nombre = Request.Form["nombre"];
                string Marca = Request.Form["marca"];
                string Modelo = Request.Form["modelo"];
                string Caracteristicas = Request.Form["caracteristicas"];
                int DepositoId = int.Parse(Request.Form["deposito"]);
                double PrecioBaseAlquiler = double.Parse(Request.Form["precio"]);
                string Codigo = Request.Form["codigo"];
                string Estado = Request.Form["estado"];
                int Stock = int.Parse(Request.Form["stock"]);

                Equipamiento unEquipamiento = new Equipamiento(
                    Id, Nombre, Marca, Modelo, Caracteristicas, DepositoId,
                    PrecioBaseAlquiler, Codigo, Estado, Stock, true);

                Controladora unaControladora = new Controladora();

                if (!unaControladora.AltaEquipamiento(unEquipamiento))
                {
                    throw new Exception("Ya existe un equipamiento con ese ID");
                }

                return Redirect("/PageEquipamiento/Listar");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;

                Controladora unaControladora = new Controladora();
                ListaDepositos = unaControladora.ListarDepositos();

                return Page();
            }
        }
    }
}