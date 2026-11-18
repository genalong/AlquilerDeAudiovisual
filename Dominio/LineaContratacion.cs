namespace AlquilerAudiovisual.Dominio
{
    public class LineaContratacion
    {
        private int aId;
        private int aContratacionId;
        private int aEquipamientoId;
        private int aCantidad;
        private double aPrecioUnitario;

        public int Id { get { return aId; } set { aId = value; } }
        public int ContratacionId { get { return aContratacionId; } set { aContratacionId = value; } }
        public int EquipamientoId { get { return aEquipamientoId; } set { aEquipamientoId = value; } }
        public int Cantidad { get { return aCantidad; } set { aCantidad = value; } }
        public double PrecioUnitario { get { return aPrecioUnitario; } set { aPrecioUnitario = value; } }

        public LineaContratacion(int pId, int pContratacionId, int pEquipamientoId,
                                 int pCantidad, double pPrecioUnitario)
        {
            aId = pId;
            aContratacionId = pContratacionId;
            aEquipamientoId = pEquipamientoId;
            aCantidad = pCantidad;
            aPrecioUnitario = pPrecioUnitario;
        }

        public LineaContratacion()
        {
            aId = 0;
            aContratacionId = 0;
            aEquipamientoId = 0;
            aCantidad = 0;
            aPrecioUnitario = 0;
        }
    }
}