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

        #region " Solicitudes "
        public List<SolicitudAlquiler> ListaSolicitudes()
        {
            return new PSolicitud().ListaSolicitudes();
        }
        public bool AltaSolicitud(SolicitudAlquiler mSolicitud)
        {
            return new PSolicitud().Alta(mSolicitud);
        }
        public bool BajaSolicitud(int pId)
        {
            return new PSolicitud().Baja(pId);
        }
        public bool ModificarSolicitud(SolicitudAlquiler mSolicitud)
        {
            return new PSolicitud().Modificar(mSolicitud);
        }
        public int ProximoSolicitudId()
        {
            return new PSolicitud().ProximoId();
        }
        #endregion

        #region " LineasSolicitud "
        public List<LineaSolicitud> ListaLineasSolicitud()
        {
            return new PLineaSolicitud().ListaLineasSolicitud();
        }
        public bool AltaLineaSolicitud(LineaSolicitud mLinea)
        {
            return new PLineaSolicitud().Alta(mLinea);
        }
        public bool BajaLineaSolicitud(int pId)
        {
            return new PLineaSolicitud().Baja(pId);
        }
        public int ProximoLineaSolicitudId()
        {
            return new PLineaSolicitud().ProximoId();
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

        #region " LineasContratacion "
        public List<LineaContratacion> ListaLineasContratacion()
        {
            return new PLineaContratacion().ListaLineasContratacion();
        }
        public bool AltaLineaContratacion(LineaContratacion mLinea)
        {
            return new PLineaContratacion().Alta(mLinea);
        }
        public bool BajaLineaContratacion(int pId)
        {
            return new PLineaContratacion().Baja(pId);
        }
        public int ProximoLineaContratacionId()
        {
            return new PLineaContratacion().ProximoId();
        }
        #endregion

        #region " Devoluciones "
        public List<Devolucion> ListaDevoluciones()
        {
            return new PDevolucion().ListaDevoluciones();
        }
        public bool AltaDevolucion(Devolucion mDevolucion)
        {
            return new PDevolucion().Alta(mDevolucion);
        }
        public bool BajaDevolucion(int pId)
        {
            return new PDevolucion().Baja(pId);
        }
        public bool ModificarDevolucion(Devolucion mDevolucion)
        {
            return new PDevolucion().Modificar(mDevolucion);
        }
        public int ProximoDevolucionId()
        {
            return new PDevolucion().ProximoId();
        }
        #endregion

        #region " DetallesDevolucion "
        public List<DetalleDevolucion> ListaDetallesDevolucion()
        {
            return new PDetalleDevolucion().ListaDetallesDevolucion();
        }
        public bool AltaDetalleDevolucion(DetalleDevolucion mDetalle)
        {
            return new PDetalleDevolucion().Alta(mDetalle);
        }
        public bool BajaDetalleDevolucion(int pId)
        {
            return new PDetalleDevolucion().Baja(pId);
        }
        public int ProximoDetalleDevolucionId()
        {
            return new PDetalleDevolucion().ProximoId();
        }
        #endregion

        #region " Pagos "
        public List<Pago> ListaPagos()
        {
            return new PPago().ListaPagos();
        }
        public bool AltaPago(Pago mPago)
        {
            return new PPago().Alta(mPago);
        }
        public bool BajaPago(int pId)
        {
            return new PPago().Baja(pId);
        }
        public bool ModificarPago(Pago mPago)
        {
            return new PPago().Modificar(mPago);
        }
        public int ProximoPagoId()
        {
            return new PPago().ProximoId();
        }
        #endregion
    }
}