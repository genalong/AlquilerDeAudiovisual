namespace AlquilerAudiovisual.Dominio
{
    public class ClienteEmpresa : Cliente
    {
        private string aRazonSocial;

        private string aRut;

        public string RazonSocial
        {
            get { return aRazonSocial; }
            set { aRazonSocial = value; }
        }

        public string Rut
        {
            get { return aRut; }
            set { aRut = value; }
        }

    }
}
