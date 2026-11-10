namespace AlquilerAudiovisual.Dominio
{
    public class Evento
    {
        private int aId;
        private string aTipo;
        private string aUbicacion;
        private DateTime aFecha;
        private int aCantidadAsistentes;

        public int Id
        {
            get { return aId; }
            set { aId = value; }
        }

        public string Tipo
        {
            get { return aTipo; }
            set { aTipo = value; }
        }

        public DateTime Fecha
        {
            get { return aFecha; }
            set { aFecha = value; }
        }

    }
}
