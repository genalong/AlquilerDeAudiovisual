namespace AlquilerAudiovisual.Dominio
{
    public class DetalleDevolucion
    {
        private int aId;
        private int aCantidadDevuelta;
        private string aObservacion = "";

        public int CantidadDevuelta
        {
            get { return aCantidadDevuelta; }
            set { aCantidadDevuelta = value; }
        }

        public string Observacion
        {
            get { return aObservacion; }
            set { aObservacion = value; }
        }
    }
}
