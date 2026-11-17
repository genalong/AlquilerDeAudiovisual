namespace AlquilerAudiovisual.Dominio
{
    public class DetalleDevolucion
    {
        private int aId;
        private string aEstadoRecepcion = "";
        private string aObservaciones = "";
        private Devolucion aDevolucion;
        private DetalleContratacion aDetalleContratacion;

        public int Id
        {
            get { return aId; }
            set { aId = value; }
        }

        public string EstadoRecepcion
        {
            get { return aEstadoRecepcion; }
            set { aEstadoRecepcion = value; }
        }

        public string Observaciones
        {
            get { return aObservaciones; }
            set { aObservaciones = value; }
        }

        public Devolucion Devolucion
        {
            get { return aDevolucion; }
            set { aDevolucion = value; }
        }

        public DetalleContratacion DetalleContratacion
        {
            get { return aDetalleContratacion; }
            set { aDetalleContratacion = value; }
        }

        public DetalleDevolucion(int pId, string pEstadoRecepcion,
            string pObservaciones, Devolucion pDevolucion,
            DetalleContratacion pDetalleContratacion)
        {
            aId = pId;
            aEstadoRecepcion = pEstadoRecepcion;
            aObservaciones = pObservaciones;
            aDevolucion = pDevolucion;
            aDetalleContratacion = pDetalleContratacion;
        }
    }
}