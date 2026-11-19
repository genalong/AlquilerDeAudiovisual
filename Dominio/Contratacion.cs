namespace AlquilerAudiovisual.Dominio
{
    public class Contratacion
    {
        private int aId;
        private int aSolicitudId;
        private int aClienteId;
        private DateTime aFechaInicio;
        private DateTime aFechaFin;
        private string aUbicacion;
        private double aImporteTotal;
        private string aEstado;
        private List<LineaContratacion> aLineas;

        public int Id { get { return aId; } set { aId = value; } }
        public int SolicitudId { get { return aSolicitudId; } set { aSolicitudId = value; } }
        public int ClienteId { get { return aClienteId; } set { aClienteId = value; } }
        public DateTime FechaInicio { get { return aFechaInicio; } set { aFechaInicio = value; } }
        public DateTime FechaFin { get { return aFechaFin; } set { aFechaFin = value; } }
        public string Ubicacion { get { return aUbicacion; } set { aUbicacion = value; } }
        public double ImporteTotal { get { return aImporteTotal; } set { aImporteTotal = value; } }
        public string Estado { get { return aEstado; } set { aEstado = value; } }
        public List<LineaContratacion> Lineas { get { return aLineas; } set { aLineas = value; } }

        public Contratacion(int pId, int pSolicitudId, int pClienteId,
                            DateTime pFechaInicio, DateTime pFechaFin, string pUbicacion,
                            double pImporteTotal, string pEstado)
        {
            aId = pId;
            aSolicitudId = pSolicitudId;
            aClienteId = pClienteId;
            aFechaInicio = pFechaInicio;
            aFechaFin = pFechaFin;
            aUbicacion = pUbicacion;
            aImporteTotal = pImporteTotal;
            aEstado = pEstado;
            aLineas = new List<LineaContratacion>();
        }

        public Contratacion()
        {
            aId = 0;
            aSolicitudId = 0;
            aClienteId = 0;
            aFechaInicio = DateTime.Now;
            aFechaFin = DateTime.Now;
            aUbicacion = "";
            aImporteTotal = 0;
            aEstado = "En preparación";
            aLineas = new List<LineaContratacion>();
        }
    }
}