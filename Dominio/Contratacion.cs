
namespace AlquilerAudiovisual.Dominio
{
    public class Contratacion
    {
        private int aId;
        private DateTime aFecha;
        private double aTotal;
        private string aEstado = "";

        public int Id { get { return aId; } set { aId = value; } }
        public DateTime Fecha { get { return aFecha; } set { aFecha = value; } }
        public double Total { get { return aTotal; } set { aTotal = value; } }
        public string Estado { get { return aEstado; } set { aEstado = value; } }

        public Contratacion(int pId, DateTime pFecha, double pTotal, string pEstado)
        {
            aId = pId;
            aFecha = pFecha;
            aTotal = pTotal;
            aEstado = pEstado;
        }
    }
}
