namespace AlquilerAudiovisual.Dominio
{
    public class Cliente
    {
        private int aId;
        private string aNombre;
        private string aTelefono;
        private string aEmail;
        private string aDireccion;

        public int Id { get { return aId; } set { aId = value; } }
        public string Nombre { get { return aNombre; } set { aNombre = value; } }
        public string Telefono { get { return aTelefono; } set { aTelefono = value; } }
        public string Email { get { return aEmail; } set { aEmail = value; } }
        public string Direccion { get { return aDireccion; } set { aDireccion = value; } }

        public Cliente(int pId, string pNombre, string pTelefono, string pEmail, string pDireccion)
        {
            aId = pId;
            aNombre = pNombre;
            aTelefono = pTelefono;
            aEmail = pEmail;
            aDireccion = pDireccion;
        }
    }
}
