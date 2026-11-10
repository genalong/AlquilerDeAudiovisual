namespace AlquilerAudiovisual.Dominio
{
    public class Pago
    {
        private int aId;
        private DateTime aFecha;
        
        private double aImporte;

        private string aMetodo = "";

        public int Id
        {
            get { return aId; }
            set { aId = value; }
        }

        public double Importe
        {
            get { return aImporte; }
            set { aImporte = value; }
        }

        public string Metodo
        {
            get { return aMetodo; }
            set { aMetodo = value; }
        }
    }
}
