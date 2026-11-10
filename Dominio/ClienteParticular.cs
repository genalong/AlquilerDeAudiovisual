namespace AlquilerAudiovisual.Dominio
{
    public class ClienteParticular : Cliente
    {
        public string aDocumento;

        public string Documento
        {
            get { return aDocumento; }
            set { aDocumento = value; }
        }

    }
}
