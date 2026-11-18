namespace AlquilerAudiovisual.Dominio
{
    public class DetalleDevolucion
    {
        private int aId;
        private int aDevolucionId;
        private int aEquipamientoId;
        private int aCantidad;
        private string aTipoIncidencia;   // "Correcta" | "Daño" | "Faltante" | "Requiere mantenimiento"
        private double aCargoAdicional;
        private string aObservacion;

        public int Id { get { return aId; } set { aId = value; } }
        public int DevolucionId { get { return aDevolucionId; } set { aDevolucionId = value; } }
        public int EquipamientoId { get { return aEquipamientoId; } set { aEquipamientoId = value; } }
        public int Cantidad { get { return aCantidad; } set { aCantidad = value; } }
        public string TipoIncidencia { get { return aTipoIncidencia; } set { aTipoIncidencia = value; } }
        public double CargoAdicional { get { return aCargoAdicional; } set { aCargoAdicional = value; } }
        public string Observacion { get { return aObservacion; } set { aObservacion = value; } }

        public DetalleDevolucion(int pId, int pDevolucionId, int pEquipamientoId,
                                 int pCantidad, string pTipoIncidencia,
                                 double pCargoAdicional, string pObservacion)
        {
            aId = pId;
            aDevolucionId = pDevolucionId;
            aEquipamientoId = pEquipamientoId;
            aCantidad = pCantidad;
            aTipoIncidencia = pTipoIncidencia;
            aCargoAdicional = pCargoAdicional;
            aObservacion = pObservacion;
        }

        public DetalleDevolucion()
        {
            aId = 0;
            aDevolucionId = 0;
            aEquipamientoId = 0;
            aCantidad = 0;
            aTipoIncidencia = "Correcta";
            aCargoAdicional = 0;
            aObservacion = "";
        }
    }
}