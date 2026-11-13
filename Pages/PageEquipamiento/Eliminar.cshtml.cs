
using AlquilerAudiovisual.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlquilerAudiovisual.Pages.PageEquipamiento
{
    public class EliminarModel : PageModel
    {
        public string Mensaje { get; set; } = "";
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Tipo { get; set; } = "";

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

            return Page();
        }

        public IActionResult OnPostEliminar()
        {
            try
            {
                if (!int.TryParse(Request.Form["id"], out int IdEquipamiento))
                {
                    throw new Exception("El ID del Equipamiento no es válido");
                }

                Controladora unaControladora = new Controladora();

                bool Eliminado = unaControladora.BajaEquipamiento(IdEquipamiento);

                if (Eliminado)
                {
                    return RedirectToPage("./Listar");
                }

                throw new Exception("No se pudo eliminar el Equipamiento");
            }
            catch (Exception Error)
            {
                Mensaje = Error.Message;
                return Page();
            }
        }
    }
}
