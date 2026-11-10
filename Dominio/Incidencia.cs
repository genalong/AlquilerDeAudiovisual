namespace AlquilerAudiovisual.Dominio
{
    public class Incidencia
    {

        private int aId;
        private string aDescripcion = "";
        private string aTipo = "";

        private double aCosto;

        public int Id
        {
            get { return aId; }
            set { aId = value; }
        }

        public string Descripcion
        {
            get { return aDescripcion; }
            set { aDescripcion = value; }
        }

        public double Costo
        {
            get { return aCosto; }
            set { aCosto = value; }
        }
    }
}
