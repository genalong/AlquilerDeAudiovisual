namespace AlquilerAudiovisual.Dominio
{
    public class ClienteEmpresa : Cliente
    {
        private string aRazonSocial;
        private string aRut;

        public string RazonSocial { get { return aRazonSocial; } set { aRazonSocial = value; } }
        public string RUT { get { return aRut; } set { aRut = value; } }

        public ClienteEmpresa(int pId, string pNombre, string pTelefono, string pEmail, string pDireccion, string pRazonSocial, string pRut)
            : base(pId, pNombre, pTelefono, pEmail, pDireccion)
        {
            aRazonSocial = pRazonSocial;
            aRut = pRut;
        }
    }
}
