namespace AlquilerAudiovisual.Dominio
{
    public class Contratacion
    {
        private int aId;
        private int aSolicitudId;
        private int aClienteId;
        private DateTime aFechaEvento;
        private string aUbicacion;
        private string aHoraInicio;
        private string aHoraFin;
        private double aImporteTotal;
        private string aEstado;          // "En preparación" | "Activa" | "Finalizada" | "Cancelada"
        private List<LineaContratacion> aLineas;

        public int Id { get { return aId; } set { aId = value; } }
        public int SolicitudId { get { return aSolicitudId; } set { aSolicitudId = value; } }
        public int ClienteId { get { return aClienteId; } set { aClienteId = value; } }
        public DateTime FechaEvento { get { return aFechaEvento; } set { aFechaEvento = value; } }
        public string Ubicacion { get { return aUbicacion; } set { aUbicacion = value; } }
        public string HoraInicio { get { return aHoraInicio; } set { aHoraInicio = value; } }
        public string HoraFin { get { return aHoraFin; } set { aHoraFin = value; } }
        public double ImporteTotal { get { return aImporteTotal; } set { aImporteTotal = value; } }
        public string Estado { get { return aEstado; } set { aEstado = value; } }
        public List<LineaContratacion> Lineas { get { return aLineas; } set { aLineas = value; } }

        public Contratacion(int pId, int pSolicitudId, int pClienteId,
                            DateTime pFechaEvento, string pUbicacion,
                            string pHoraInicio, string pHoraFin,
                            double pImporteTotal, string pEstado)
        {
            aId = pId;
            aSolicitudId = pSolicitudId;
            aClienteId = pClienteId;
            aFechaEvento = pFechaEvento;
            aUbicacion = pUbicacion;
            aHoraInicio = pHoraInicio;
            aHoraFin = pHoraFin;
            aImporteTotal = pImporteTotal;
            aEstado = pEstado;
            aLineas = new List<LineaContratacion>();
        }

        public Contratacion()
        {
            aId = 0;
            aSolicitudId = 0;
            aClienteId = 0;
            aFechaEvento = DateTime.Now;
            aUbicacion = "";
            aHoraInicio = "";
            aHoraFin = "";
            aImporteTotal = 0;
            aEstado = "En preparación";
            aLineas = new List<LineaContratacion>();
        }
    }
}