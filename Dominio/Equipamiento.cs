namespace AlquilerAudiovisual.Dominio
{
    public class Equipamiento
    {
        private int aId;
        private string aNombre = "";
        private string aTipo = "";
        private string aDescripcion = "";
        private double aPrecioAlquiler;

        public int Id
        {
            get { return aId; }
            set { aId = value; }
        }

        public string Nombre
        {
            get { return aNombre; }
            set { aNombre = value; }
        }

        public string Tipo
        {
            get { return aTipo; }
            set { aTipo = value; }
        }

        public double PrecioAlquiler
        {
            get { return aPrecioAlquiler; }
            set { aPrecioAlquiler = value; }
        }
    }
}
