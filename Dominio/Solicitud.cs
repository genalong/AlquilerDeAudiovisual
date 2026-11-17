namespace AlquilerAudiovisual.Dominio
{
    public class Solicitud
    {
        private int aId;
        private DateTime aFechaSolicitud;
        private DateTime aFechaInicio;
        private DateTime aFechaFin;
        private string aEstado = "";
        private Cliente aCliente;
        private Evento aEvento;

        public int Id { get { return aId; } set { aId = value; } }
        public DateTime FechaSolicitud { get { return aFechaSolicitud; } set { aFechaSolicitud = value; } }
        public DateTime FechaInicio { get { return aFechaInicio; } set { aFechaInicio = value; } }
        public DateTime FechaFin { get { return aFechaFin; } set { aFechaFin = value; } }
        public string Estado { get { return aEstado; } set { aEstado = value; } }
        public Cliente Cliente { get { return aCliente; } set { aCliente = value; } }
        public Evento Evento { get { return aEvento; } set { aEvento = value; } }

        public Solicitud(int pId, DateTime pFechaSolicitud, DateTime pFechaInicio, DateTime pFechaFin, string pEstado, Cliente pCliente, Evento pEvento)
        {
            aId = pId;
            aFechaSolicitud = pFechaSolicitud;
            aFechaInicio = pFechaInicio;
            aFechaFin = pFechaFin;
            aEstado = pEstado;
            aCliente = pCliente;
            aEvento = pEvento;
        }
    }
}