namespace AlquilerAudiovisual.Dominio
{
    public class Devolucion
    {
        private int aId;
        private DateTime aFecha;
        private string aModalidad = "";
        private string aLugarDevolucion = "";
        private string aObservaciones = "";
        private Contratacion aContratacion;

        public int Id { get { return aId; } set { aId = value; } }
        public DateTime Fecha { get { return aFecha; } set { aFecha = value; } }
        public string Modalidad { get { return aModalidad; } set { aModalidad = value; } }
        public string LugarDevolucion { get { return aLugarDevolucion; } set { aLugarDevolucion = value; } }
        public string Observaciones { get { return aObservaciones; } set { aObservaciones = value; } }
        public Contratacion Contratacion { get { return aContratacion; } set { aContratacion = value; } }

        public Devolucion(int pId, DateTime pFecha, string pModalidad,
            string pLugarDevolucion, string pObservaciones,
            Contratacion pContratacion)
        {
            aId = pId;
            aFecha = pFecha;
            aModalidad = pModalidad;
            aLugarDevolucion = pLugarDevolucion;
            aObservaciones = pObservaciones;
            aContratacion = pContratacion;
        }
    }
}