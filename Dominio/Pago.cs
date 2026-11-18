namespace AlquilerAudiovisual.Dominio
{
    public class Pago
    {
        private int aId;
        private int aContratacionId;
        private DateTime aFechaPago;
        private double aMonto;
        private string aMetodoPago;   // "Efectivo" | "Transferencia" | "Tarjeta"
        private string aObservacion;

        public int Id { get { return aId; } set { aId = value; } }
        public int ContratacionId { get { return aContratacionId; } set { aContratacionId = value; } }
        public DateTime FechaPago { get { return aFechaPago; } set { aFechaPago = value; } }
        public double Monto { get { return aMonto; } set { aMonto = value; } }
        public string MetodoPago { get { return aMetodoPago; } set { aMetodoPago = value; } }
        public string Observacion { get { return aObservacion; } set { aObservacion = value; } }

        public Pago(int pId, int pContratacionId, DateTime pFechaPago,
                    double pMonto, string pMetodoPago, string pObservacion)
        {
            aId = pId;
            aContratacionId = pContratacionId;
            aFechaPago = pFechaPago;
            aMonto = pMonto;
            aMetodoPago = pMetodoPago;
            aObservacion = pObservacion;
        }

        public Pago()
        {
            aId = 0;
            aContratacionId = 0;
            aFechaPago = DateTime.Now;
            aMonto = 0;
            aMetodoPago = "";
            aObservacion = "";
        }
    }
}