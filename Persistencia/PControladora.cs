using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Persistencia
{
    public class PControladora
    {
        #region " Clientes "
        public List<Cliente> ListaClientes()
        {
            return new PCliente().ListaClientes();
        }
        public bool AltaCliente(Cliente mCliente)
        {
            return new PCliente().Alta(mCliente);
        }
        public bool BajaCliente(int pId)
        {
            return new PCliente().Baja(pId);
        }
        public bool ModificarCliente(Cliente mCliente)
        {
            return new PCliente().Modificar(mCliente);
        }
        public int ProximoClienteId()
        {
            return new PCliente().ProximoId();
        }
        #endregion

        #region " Depositos "
        public List<Deposito> ListaDepositos()
        {
            return new PDeposito().ListaDepositos();
        }
        public bool AltaDeposito(Deposito mDeposito)
        {
            return new PDeposito().Alta(mDeposito);
        }
        public bool BajaDeposito(int pId)
        {
            return new PDeposito().Baja(pId);
        }
        public bool ModificarDeposito(Deposito mDeposito)
        {
            return new PDeposito().Modificar(mDeposito);
        }
        public int ProximoDepositoId()
        {
            return new PDeposito().ProximoId();
        }
        #endregion

        #region " Equipamientos "
        public List<Equipamiento> ListaEquipamientos()
        {
            return new PEquipamiento().ListaEquipamientos();
        }
        public bool AltaEquipamiento(Equipamiento mEquipamiento)
        {
            return new PEquipamiento().Alta(mEquipamiento);
        }
        public bool BajaEquipamiento(int pId)
        {
            return new PEquipamiento().Baja(pId);
        }
        public bool ModificarEquipamiento(Equipamiento mEquipamiento)
        {
            return new PEquipamiento().Modificar(mEquipamiento);
        }
        public int ProximoEquipamientoId()
        {
            return new PEquipamiento().ProximoId();
        }
        #endregion

        #region " Contrataciones "
        public List<Contratacion> ListaContrataciones()
        {
            return new PContratacion().ListaContrataciones();
        }
        public bool AltaContratacion(Contratacion mContratacion)
        {
            return new PContratacion().Alta(mContratacion);
        }
        public bool BajaContratacion(int pId)
        {
            return new PContratacion().Baja(pId);
        }
        public bool ModificarContratacion(Contratacion mContratacion)
        {
            return new PContratacion().Modificar(mContratacion);
        }
        public int ProximoContratacionId()
        {
            return new PContratacion().ProximoId();
        }
        #endregion
    }
}