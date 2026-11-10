namespace AlquilerAudiovisual.Dominio
{
    public class DetalleSolicitud
    {
        private int aId;
        private int aCantidad;
        private double aPrecioEstimado;

        public int Id
        {
            get { return aId; }
            set { aId = value; }
        }

        public int Cantidad
        {
            get { return aCantidad; }
            set { aCantidad = value; }
        }

        public double PrecioEstimado
        {
            get { return aPrecioEstimado; }
            set { aPrecioEstimado = value; }
        }
    }
}
