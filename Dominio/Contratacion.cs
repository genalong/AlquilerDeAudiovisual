namespace AlquilerAudiovisual.Dominio
{
    public class Contratacion
    {
        private int aId;
        private int aClienteId;
        private int aEquipamientoId;
        private int aCantidad;
        private DateTime aFechaInicio;
        private DateTime aFechaFin;
        private string aUbicacion;
        private double aImporteTotal;
        private string aEstado; 

        public int Id { get { return aId; } set { aId = value; } }
        public int ClienteId { get { return aClienteId; } set { aClienteId = value; } }
        public int EquipamientoId { get { return aEquipamientoId; } set { aEquipamientoId = value; } }
        public int Cantidad { get { return aCantidad; } set { aCantidad = value; } }
        public DateTime FechaInicio { get { return aFechaInicio; } set { aFechaInicio = value; } }
        public DateTime FechaFin { get { return aFechaFin; } set { aFechaFin = value; } }
        public string Ubicacion { get { return aUbicacion; } set { aUbicacion = value; } }
        public double ImporteTotal { get { return aImporteTotal; } set { aImporteTotal = value; } }
        public string Estado { get { return aEstado; } set { aEstado = value; } }

        public Contratacion(int pId, int pClienteId, int pEquipamientoId, int pCantidad,
                            DateTime pFechaInicio, DateTime pFechaFin, string pUbicacion,
                            double pImporteTotal, string pEstado)
        {
            aId = pId;
            aClienteId = pClienteId;
            aEquipamientoId = pEquipamientoId;
            aCantidad = pCantidad;
            aFechaInicio = pFechaInicio;
            aFechaFin = pFechaFin;
            aUbicacion = pUbicacion;
            aImporteTotal = pImporteTotal;
            aEstado = pEstado;
        }

        public Contratacion()
        {
            aId = 0;
            aClienteId = 0;
            aEquipamientoId = 0;
            aCantidad = 0;
            aFechaInicio = DateTime.Now;
            aFechaFin = DateTime.Now;
            aUbicacion = "";
            aImporteTotal = 0;
            aEstado = "Aprobado"; 
        }
    }
}