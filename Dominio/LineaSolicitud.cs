namespace AlquilerAudiovisual.Dominio
{
    public class LineaSolicitud
    {
        private int aId;
        private int aSolicitudId;
        private int aEquipamientoId;
        private int aCantidad;

        public int Id { get { return aId; } set { aId = value; } }
        public int SolicitudId { get { return aSolicitudId; } set { aSolicitudId = value; } }
        public int EquipamientoId { get { return aEquipamientoId; } set { aEquipamientoId = value; } }
        public int Cantidad { get { return aCantidad; } set { aCantidad = value; } }

        public LineaSolicitud(int pId, int pSolicitudId, int pEquipamientoId, int pCantidad)
        {
            aId = pId;
            aSolicitudId = pSolicitudId;
            aEquipamientoId = pEquipamientoId;
            aCantidad = pCantidad;
        }

        public LineaSolicitud()
        {
            aId = 0;
            aSolicitudId = 0;
            aEquipamientoId = 0;
            aCantidad = 0;
        }
    }
}