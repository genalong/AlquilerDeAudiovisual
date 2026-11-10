namespace AlquilerAudiovisual.Dominio
{
    public class EquipoIndividual
    {
        private int aId;
        private string aNumeroSerie = "";
        private string aEstado = "";
        private Deposito aDeposito;

        public int Id
        {
            get { return aId; }
            set { aId = value; }
        }

        public string NumeroSerie
        {
            get { return aNumeroSerie; }
            set { aNumeroSerie = value; }
        }

        public string Estado
        {
            get { return aEstado; }
            set { aEstado = value; }
        }

        public Deposito Deposito
        {
            get { return aDeposito; }
            set { aDeposito = value; }
        }
    }
}
