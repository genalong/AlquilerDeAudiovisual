namespace AlquilerAudiovisual.Dominio
{
    public class Devolucion
    {
        private int aId;
        private int aContratacionId;
        private DateTime aFechaDevolucion;
        private double aCargoAdicionalTotal;
        private string aObservaciones;
        private List<DetalleDevolucion> aDetalles;

        public int Id { get { return aId; } set { aId = value; } }
        public int ContratacionId { get { return aContratacionId; } set { aContratacionId = value; } }
        public DateTime FechaDevolucion { get { return aFechaDevolucion; } set { aFechaDevolucion = value; } }
        public double CargoAdicionalTotal { get { return aCargoAdicionalTotal; } set { aCargoAdicionalTotal = value; } }
        public string Observaciones { get { return aObservaciones; } set { aObservaciones = value; } }
        public List<DetalleDevolucion> Detalles { get { return aDetalles; } set { aDetalles = value; } }

        public Devolucion(int pId, int pContratacionId, DateTime pFechaDevolucion,
                          double pCargoAdicionalTotal, string pObservaciones)
        {
            aId = pId;
            aContratacionId = pContratacionId;
            aFechaDevolucion = pFechaDevolucion;
            aCargoAdicionalTotal = pCargoAdicionalTotal;
            aObservaciones = pObservaciones;
            aDetalles = new List<DetalleDevolucion>();
        }

        public Devolucion()
        {
            aId = 0;
            aContratacionId = 0;
            aFechaDevolucion = DateTime.Now;
            aCargoAdicionalTotal = 0;
            aObservaciones = "";
            aDetalles = new List<DetalleDevolucion>();
        }
    }
}