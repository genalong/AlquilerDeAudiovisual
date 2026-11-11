
namespace AlquilerAudiovisual.Dominio
{
    public class DetalleContratacion
    {
        private int aId;
        private int aCantidad;
        private double aPrecioAcordado;

        public int Id { get { return aId; } set { aId = value; } }
        public int Cantidad { get { return aCantidad; } set { aCantidad = value; } }
        public double PrecioAcordado { get { return aPrecioAcordado; } set { aPrecioAcordado = value; } }

        public DetalleContratacion(int pId, int pCantidad, double pPrecioAcordado)
        {
            aId = pId;
            aCantidad = pCantidad;
            aPrecioAcordado = pPrecioAcordado;
        }
    }
}
