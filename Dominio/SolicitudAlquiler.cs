namespace AlquilerAudiovisual.Dominio
{
    public class SolicitudAlquiler
    {
        private int aId;
        private int aClienteId;
        private string aNombreEvento;
        private DateTime aFechaEvento;
        private string aUbicacion;
        private string aHoraInicio;      // "HH:mm"
        private string aHoraFin;         // "HH:mm"
        private int aCantidadAsistentes;
        private string aEstado;          // "Pendiente" | "Aceptada" | "Rechazada" | "Cancelada"
        private List<LineaSolicitud> aLineas;

        public int Id { get { return aId; } set { aId = value; } }
        public int ClienteId { get { return aClienteId; } set { aClienteId = value; } }
        public string NombreEvento { get { return aNombreEvento; } set { aNombreEvento = value; } }
        public DateTime FechaEvento { get { return aFechaEvento; } set { aFechaEvento = value; } }
        public string Ubicacion { get { return aUbicacion; } set { aUbicacion = value; } }
        public string HoraInicio { get { return aHoraInicio; } set { aHoraInicio = value; } }
        public string HoraFin { get { return aHoraFin; } set { aHoraFin = value; } }
        public int CantidadAsistentes { get { return aCantidadAsistentes; } set { aCantidadAsistentes = value; } }
        public string Estado { get { return aEstado; } set { aEstado = value; } }
        public List<LineaSolicitud> Lineas { get { return aLineas; } set { aLineas = value; } }

        public SolicitudAlquiler(int pId, int pClienteId, string pNombreEvento,
                                 DateTime pFechaEvento, string pUbicacion,
                                 string pHoraInicio, string pHoraFin,
                                 int pCantidadAsistentes, string pEstado)
        {
            aId = pId;
            aClienteId = pClienteId;
            aNombreEvento = pNombreEvento;
            aFechaEvento = pFechaEvento;
            aUbicacion = pUbicacion;
            aHoraInicio = pHoraInicio;
            aHoraFin = pHoraFin;
            aCantidadAsistentes = pCantidadAsistentes;
            aEstado = pEstado;
            aLineas = new List<LineaSolicitud>();
        }

        public SolicitudAlquiler()
        {
            aId = 0;
            aClienteId = 0;
            aNombreEvento = "";
            aFechaEvento = DateTime.Now;
            aUbicacion = "";
            aHoraInicio = "";
            aHoraFin = "";
            aCantidadAsistentes = 0;
            aEstado = "Pendiente";
            aLineas = new List<LineaSolicitud>();
        }
    }
}