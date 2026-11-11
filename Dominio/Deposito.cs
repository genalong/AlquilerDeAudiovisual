
namespace AlquilerAudiovisual.Dominio
{
    public class Deposito
    {
        private int aId;
        private string aNombre = "";
        private string aDireccion = "";

        public int Id { get { return aId; } set { aId = value; } }
        public string Nombre { get { return aNombre; } set { aNombre = value; } }
        public string Direccion { get { return aDireccion; } set { aDireccion = value; } }

        public Deposito(int pId, string pNombre, string pDireccion)
        {
            aId = pId;
            aNombre = pNombre;
            aDireccion = pDireccion;
        }
    }
}
