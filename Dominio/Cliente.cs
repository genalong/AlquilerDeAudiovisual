namespace AlquilerAudiovisual.Dominio
{
    public class Cliente
    {
        private int aId;
        private string aNombre;
        private string aTipo;        
        private string aDocumento;   
        private string aEmail;
        private string aTelefono;
        private string aDireccion;
        private bool aActivo;

        public int Id { get { return aId; } set { aId = value; } }
        public string Nombre { get { return aNombre; } set { aNombre = value; } }
        public string Tipo { get { return aTipo; } set { aTipo = value; } }
        public string Documento { get { return aDocumento; } set { aDocumento = value; } }
        public string Email { get { return aEmail; } set { aEmail = value; } }
        public string Telefono { get { return aTelefono; } set { aTelefono = value; } }
        public string Direccion { get { return aDireccion; } set { aDireccion = value; } }
        public bool Activo { get { return aActivo; } set { aActivo = value; } }

        public Cliente(int pId, string pNombre, string pTipo, string pDocumento,
                       string pEmail, string pTelefono, string pDireccion, bool pActivo)
        {
            aId = pId;
            aNombre = pNombre;
            aTipo = pTipo;
            aDocumento = pDocumento;
            aEmail = pEmail;
            aTelefono = pTelefono;
            aDireccion = pDireccion;
            aActivo = pActivo;
        }

        public Cliente()
        {
            aId = 0;
            aNombre = "";
            aTipo = "";
            aDocumento = "";
            aEmail = "";
            aTelefono = "";
            aDireccion = "";
            aActivo = true;
        }
    }
}