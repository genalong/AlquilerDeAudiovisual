
namespace AlquilerAudiovisual.Dominio
{
    public class Evento
    {
        private int aId;
        private string aTipo;
        private string aUbicacion;
        private DateTime aFecha;
        private int aCantidadAsistentes;

        public int Id { get { return aId; } set { aId = value; } }
        public string Tipo { get { return aTipo; } set { aTipo = value; } }
        public DateTime Fecha { get { return aFecha; } set { aFecha = value; } }

        public Evento(int pId, string pTipo, string pUbicacion, DateTime pFecha, int pCantidadAsistentes)
        {
            aId = pId;
            aTipo = pTipo;
            aUbicacion = pUbicacion;
            aFecha = pFecha;
            aCantidadAsistentes = pCantidadAsistentes;
        }
    }
}
