namespace AlquilerAudiovisual.Dominio
{
    public class DetalleContratacion
    {
        private int aId;
        private int aCantidad;
        private double aPrecioAcordado;

        public int Cantidad
        {
            get { return aCantidad; }
            set { aCantidad = value; }
        }

        public double PrecioAcordado
        {
            get { return aPrecioAcordado; }
            set { aPrecioAcordado = value; }
        }

    }
}
