
namespace AlquilerAudiovisual.Dominio
{
    public class Devolucion
    {
        private int aId;
        private DateTime aFecha;
        private string aObservacion = "";

        public int Id { get { return aId; } set { aId = value; } }
        public DateTime Fecha { get { return aFecha; } set { aFecha = value; } }
        public string Observacion { get { return aObservacion; } set { aObservacion = value; } }

        public Devolucion(int pId, DateTime pFecha, string pObservacion)
        {
            aId = pId;
            aFecha = pFecha;
            aObservacion = pObservacion;
        }
    }
}
