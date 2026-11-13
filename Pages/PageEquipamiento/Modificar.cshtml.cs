
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageEquipamiento
{
    public class ModificarModel : PageModel
    {
        public string Mensaje { get; set; } = "";
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Tipo { get; set; } = "";
        public double PrecioAlquiler { get; set; }

        public IActionResult OnGet(int id)
        {
            Controladora unaControladora = new Controladora();

            Equipamiento unEquipamiento = unaControladora.BuscarEquipamiento(id);

            if (unEquipamiento == null)
            {
                return RedirectToPage("./Listar");
            }

            Id = unEquipamiento.Id;
            Nombre = unEquipamiento.Nombre;
            Tipo = unEquipamiento.Tipo;
            PrecioAlquiler = unEquipamiento.PrecioAlquiler;

            return Page();
        }

        public IActionResult OnPostModificar()
        {
            try
            {
                if (!int.TryParse(Request.Form["id"], out int IdEquipamiento))
                {
                    throw new Exception("El ID del Equipamiento no es válido");
                }

                if (Request.Form["nombre"] == "")
                {
                    throw new Exception("Debe ingresar el Nombre del Equipamiento");
                }

                if (Request.Form["tipo"] == "")
                {
                    throw new Exception("Debe ingresar el Tipo del Equipamiento");
                }

                if (!double.TryParse(Request.Form["precioAlquiler"], out double Precio))
                {
                    throw new Exception("El Precio de Alquiler debe ser un numero");
                }

                string NombreEquipamiento = Request.Form["nombre"];
                string TipoEquipamiento = Request.Form["tipo"];

                Controladora unaControladora = new Controladora();

                bool Modificado = unaControladora.ModificarEquipamiento(
                    IdEquipamiento,
                    NombreEquipamiento,
                    TipoEquipamiento,
                    Precio
                );

                if (Modificado)
                {
                    return RedirectToPage("./Listar");
                }

                throw new Exception("No se pudo modificar el Equipamiento");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;

                int.TryParse(Request.Form["id"], out int IdFormulario);
                Id = IdFormulario;
                Nombre = Request.Form["nombre"];
                Tipo = Request.Form["tipo"];
                double.TryParse(Request.Form["precioAlquiler"], out double PrecioFormulario);
                PrecioAlquiler = PrecioFormulario;

                return Page();
            }
        }
    }
}
