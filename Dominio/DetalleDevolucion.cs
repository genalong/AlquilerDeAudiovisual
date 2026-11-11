
namespace AlquilerAudiovisual.Dominio
{
    public class DetalleDevolucion
    {
        private int aId;
        private int aCantidadDevuelta;
        private string aEstado = "";
        private string aObservacion = "";

        public int CantidadDevuelta { get { return aCantidadDevuelta; } set { aCantidadDevuelta = value; } }
        public string Estado { get { return aEstado; } set { aEstado = value; } }

        public DetalleDevolucion(int pId, int pCantidadDevuelta, string pEstado, string pObservacion)
        {
            aId = pId;
            aCantidadDevuelta = pCantidadDevuelta;
            aEstado = pEstado;
            aObservacion = pObservacion;
        }
    }
}
