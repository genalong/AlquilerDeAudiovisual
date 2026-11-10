namespace AlquilerAudiovisual.Dominio
{
    public class Solicitud
    {
        private int aId;
        private DateTime aFechaSolicitud;

        private DateTime aFechaInicio;

        private DateTime aFechaFin;

        private string aEstado = "";

        public int Id
        {
            get { return aId; }
            set { aId = value; }
        }

        public string Estado
        {
            get { return aEstado; }
            set { aEstado = value; }
        }

    }
}
