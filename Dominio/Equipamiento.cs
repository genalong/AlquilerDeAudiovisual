namespace AlquilerAudiovisual.Dominio
{
    public class Equipamiento
    {
        private int aId;
        private string aNombre;
        private string aMarca;
        private string aModelo;
        private string aCaracteristicas;
        private int aDepositoId;
        private double aPrecioBaseAlquiler;
        private string aCodigo;        // identifica el ítem / lote
        private string aEstado;        // "Disponible", "Reservado", "En preparación",
                                       // "Alquilado", "En mantenimiento", "Fuera de servicio"
        private int aStock;            // cuántas unidades hay
        private bool aActivo;

        public int Id { get { return aId; } set { aId = value; } }
        public string Nombre { get { return aNombre; } set { aNombre = value; } }
        public string Marca { get { return aMarca; } set { aMarca = value; } }
        public string Modelo { get { return aModelo; } set { aModelo = value; } }
        public string Caracteristicas { get { return aCaracteristicas; } set { aCaracteristicas = value; } }
        public int DepositoId { get { return aDepositoId; } set { aDepositoId = value; } }
        public double PrecioBaseAlquiler { get { return aPrecioBaseAlquiler; } set { aPrecioBaseAlquiler = value; } }
        public string Codigo { get { return aCodigo; } set { aCodigo = value; } }
        public string Estado { get { return aEstado; } set { aEstado = value; } }
        public int Stock { get { return aStock; } set { aStock = value; } }
        public bool Activo { get { return aActivo; } set { aActivo = value; } }

        public Equipamiento(int pId, string pNombre, string pMarca, string pModelo,
                            string pCaracteristicas, int pDepositoId,
                            double pPrecioBaseAlquiler, string pCodigo,
                            string pEstado, int pStock, bool pActivo)
        {
            aId = pId;
            aNombre = pNombre;
            aMarca = pMarca;
            aModelo = pModelo;
            aCaracteristicas = pCaracteristicas;
            aDepositoId = pDepositoId;
            aPrecioBaseAlquiler = pPrecioBaseAlquiler;
            aCodigo = pCodigo;
            aEstado = pEstado;
            aStock = pStock;
            aActivo = pActivo;
        }

        public Equipamiento()
        {
            aId = 0;
            aNombre = "";
            aMarca = "";
            aModelo = "";
            aCaracteristicas = "";
            aDepositoId = 0;
            aPrecioBaseAlquiler = 0;
            aCodigo = "";
            aEstado = "Disponible";
            aStock = 0;
            aActivo = true;
        }
    }
}