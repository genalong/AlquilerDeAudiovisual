
namespace AlquilerAudiovisual.Dominio
{
    public class DetalleSolicitud
    {
        private int aId;
        private int aCantidad;
        private double aPrecioEstimado;

        private Solicitud aSolicitud;
        private Equipamiento aEquipamiento;

        public int Id { get { return aId; } set { aId = value; } }
        public int Cantidad { get { return aCantidad; } set { aCantidad = value; } }
        public double PrecioEstimado { get { return aPrecioEstimado; } set { aPrecioEstimado = value; } }

        public DetalleSolicitud(int pId, int pCantidad, double pPrecioEstimado)
        {
            aId = pId;
            aCantidad = pCantidad;
            aPrecioEstimado = pPrecioEstimado;
        }

        public Solicitud Solicitud
        {
            get { return aSolicitud; }
            set { aSolicitud = value; }
        }

        public Equipamiento Equipamiento
        {
            get { return aEquipamiento; }
            set { aEquipamiento = value; }
        }
    }
}
