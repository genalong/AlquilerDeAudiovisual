namespace AlquilerAudiovisual.Dominio
{
    public class ClienteParticular : Cliente
    {
        private string aDocumento;

        public string Documento { get { return aDocumento; } set { aDocumento = value; } }

        public ClienteParticular(int pId, string pNombre, string pTelefono, string pEmail, string pDireccion, string pDocumento)
            : base(pId, pNombre, pTelefono, pEmail, pDireccion)
        {
            aDocumento = pDocumento;
        }
    }
}
