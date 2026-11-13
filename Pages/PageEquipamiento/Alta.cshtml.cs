
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageEquipamiento
{
    public class AltaModel : PageModel
    {
        public string Mensaje { get; set; } = "";

        public void OnGet()
        {
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
                    throw new Exception("El ID debe ser un numero");
                }

                if (Request.Form["nombre"] == "")
                {
                    throw new Exception("Debe ingresar el Nombre del Equipamiento");
                }

                if (Request.Form["tipo"] == "")
                {
                    throw new Exception("Debe ingresar el Tipo del Equipamiento");
                }

                if (Request.Form["descripcion"] == "")
                {
                    throw new Exception("Debe ingresar la Descripcion del Equipamiento");
                }

                if (!double.TryParse(Request.Form["precioAlquiler"], out _))
                {
                    throw new Exception("El Precio de Alquiler debe ser un numero");
                }

                int Id = int.Parse(Request.Form["id"]);
                string Nombre = Request.Form["nombre"];
                string Tipo = Request.Form["tipo"];
                string Descripcion = Request.Form["descripcion"];
                double PrecioAlquiler = double.Parse(Request.Form["precioAlquiler"]);

                Equipamiento unEquipamiento = new Equipamiento(
                    Id, Nombre, Tipo, Descripcion, PrecioAlquiler);

                Controladora unaControladora = new Controladora();

                bool Agregado = unaControladora.AltaEquipamiento(unEquipamiento);

                if (Agregado)
                {
                    return RedirectToPage("./Listar");
                }

                throw new Exception("Ya existe un Equipamiento con ese ID");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
    }
}
