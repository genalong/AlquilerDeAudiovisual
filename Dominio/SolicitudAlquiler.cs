namespace AlquilerAudiovisual.Dominio
{
    public class SolicitudAlquiler
    {
        private int aId;
        private int aClienteId;
        private string aTipoEvento;
        private string aNombreEvento;
        private DateTime aFechaInicio;
        private DateTime aFechaFin;
        private string aUbicacion;
        private int aCantidadAsistentes;
        private string aEstado;
        private List<LineaSolicitud> aLineas;

        public int Id { get { return aId; } set { aId = value; } }
        public int ClienteId { get { return aClienteId; } set { aClienteId = value; } }
        public string TipoEvento { get { return aTipoEvento; } set { aTipoEvento = value; } }
        public string NombreEvento { get { return aNombreEvento; } set { aNombreEvento = value; } }
        public DateTime FechaInicio { get { return aFechaInicio; } set { aFechaInicio = value; } }
        public DateTime FechaFin { get { return aFechaFin; } set { aFechaFin = value; } }
        public string Ubicacion { get { return aUbicacion; } set { aUbicacion = value; } }
        public int CantidadAsistentes { get { return aCantidadAsistentes; } set { aCantidadAsistentes = value; } }
        public string Estado { get { return aEstado; } set { aEstado = value; } }
        public List<LineaSolicitud> Lineas { get { return aLineas; } set { aLineas = value; } }

        public SolicitudAlquiler(int pId, int pClienteId, string pTipoEvento, string pNombreEvento,
                                 DateTime pFechaInicio, DateTime pFechaFin, string pUbicacion,
                                 int pCantidadAsistentes, string pEstado)
        {
            aId = pId;
            aClienteId = pClienteId;
            aTipoEvento = pTipoEvento;
            aNombreEvento = pNombreEvento;
            aFechaInicio = pFechaInicio;
            aFechaFin = pFechaFin;
            aUbicacion = pUbicacion;
            aCantidadAsistentes = pCantidadAsistentes;
            aEstado = pEstado;
            aLineas = new List<LineaSolicitud>();
        }

        public SolicitudAlquiler()
        {
            aId = 0;
            aClienteId = 0;
            aTipoEvento = "";
            aNombreEvento = "";
            aFechaInicio = DateTime.Now;
            aFechaFin = DateTime.Now;
            aUbicacion = "";
            aCantidadAsistentes = 0;
            aEstado = "Pendiente";
            aLineas = new List<LineaSolicitud>();
        }
    }
}