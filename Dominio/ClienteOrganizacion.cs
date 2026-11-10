namespace AlquilerAudiovisual.Dominio
{
    public class ClienteOrganizacion : Cliente
    {
        private string aNombreOrganizacion;
        private string aResponsable;

        public string NombreOrganizacion
        {
            get { return aNombreOrganizacion; }
            set { aNombreOrganizacion = value; }
        }

        public string Responsable
        {
            get { return aResponsable; }
            set { aResponsable = value; }
        }

    }
}
