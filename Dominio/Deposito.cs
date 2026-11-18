namespace AlquilerAudiovisual.Dominio
{
    public class Deposito
    {
        private int aId;
        private string aNombre;
        private string aDireccion;
        private string aResponsable;

        public int Id { get { return aId; } set { aId = value; } }
        public string Nombre { get { return aNombre; } set { aNombre = value; } }
        public string Direccion { get { return aDireccion; } set { aDireccion = value; } }
        public string Responsable { get { return aResponsable; } set { aResponsable = value; } }

        public Deposito(int pId, string pNombre, string pDireccion, string pResponsable)
        {
            aId = pId;
            aNombre = pNombre;
            aDireccion = pDireccion;
            aResponsable = pResponsable;
        }

        public Deposito()
        {
            aId = 0;
            aNombre = "";
            aDireccion = "";
            aResponsable = "";
        }
    }
}