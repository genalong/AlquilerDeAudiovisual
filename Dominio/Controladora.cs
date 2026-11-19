using AlquilerAudiovisual.Persistencia;

namespace AlquilerAudiovisual.Dominio
{
    public class Controladora
    {
        private PControladora Persistencia;

        private static List<Cliente> aListaClientes = new List<Cliente>();
        private static List<Deposito> aListaDepositos = new List<Deposito>();
        private static List<Equipamiento> aListaEquipamientos = new List<Equipamiento>();
        private static List<SolicitudAlquiler> aListaSolicitudes = new List<SolicitudAlquiler>();
        private static List<LineaSolicitud> aListaLineasSolicitud = new List<LineaSolicitud>();
        private static List<Contratacion> aListaContrataciones = new List<Contratacion>();
        private static List<LineaContratacion> aListaLineasContratacion = new List<LineaContratacion>();
        private static List<Devolucion> aListaDevoluciones = new List<Devolucion>();
        private static List<DetalleDevolucion> aListaDetallesDevolucion = new List<DetalleDevolucion>();
        private static List<Pago> aListaPagos = new List<Pago>();

        public Controladora()
        {
            Persistencia = new PControladora();
        }

        #region Clientes

        public int ProximoIdCliente()
        {
            return Persistencia.ProximoClienteId();
        }

        public List<Cliente> ListarClientes()
        {
            aListaClientes = Persistencia.ListaClientes();
            return aListaClientes;
        }

        public Cliente BuscarCliente(int pId)
        {
            foreach (Cliente unCliente in aListaClientes)
            {
                if (unCliente.Id == pId)
                {
                    return unCliente;
                }
            }
            return null;
        }

        public bool AltaCliente(Cliente pCliente)
        {
            Cliente ComparoCliente = BuscarCliente(pCliente.Id);
            if (ComparoCliente == null)
            {
                if (Persistencia.AltaCliente(pCliente))
                {
                    aListaClientes.Add(pCliente);
                    return true;
                }
            }
            return false;
        }

        public bool BajaCliente(int pId)
        {
            Cliente ClienteAEliminar = BuscarCliente(pId);
            if (ClienteAEliminar != null)
            {
                if (Persistencia.BajaCliente(pId))
                {
                    aListaClientes.Remove(ClienteAEliminar);
                    return true;
                }
            }
            return false;
        }

        public bool ModificarCliente(int pId, string pNombre, string pTipo, string pDocumento,
                                     string pEmail, string pTelefono, string pDireccion)
        {
            Cliente ClienteAModificar = BuscarCliente(pId);
            if (ClienteAModificar != null)
            {
                ClienteAModificar.Nombre = pNombre;
                ClienteAModificar.Tipo = pTipo;
                ClienteAModificar.Documento = pDocumento;
                ClienteAModificar.Email = pEmail;
                ClienteAModificar.Telefono = pTelefono;
                ClienteAModificar.Direccion = pDireccion;
                return true;
            }
            return false;
        }

        #endregion

        #region Depositos

        public int ProximoIdDeposito()
        {
            return Persistencia.ProximoDepositoId();
        }

        public List<Deposito> ListarDepositos()
        {
            aListaDepositos = Persistencia.ListaDepositos();
            return aListaDepositos;
        }

        public Deposito BuscarDeposito(int pId)
        {
            foreach (Deposito unDeposito in aListaDepositos)
            {
                if (unDeposito.Id == pId)
                {
                    return unDeposito;
                }
            }
            return null;
        }

        public bool AltaDeposito(Deposito pDeposito)
        {
            Deposito ComparoDeposito = BuscarDeposito(pDeposito.Id);
            if (ComparoDeposito == null)
            {
                if (Persistencia.AltaDeposito(pDeposito))
                {
                    aListaDepositos.Add(pDeposito);
                    return true;
                }
            }
            return false;
        }

        public bool BajaDeposito(int pId)
        {
            Deposito DepositoAEliminar = BuscarDeposito(pId);
            if (DepositoAEliminar != null)
            {
                if (Persistencia.BajaDeposito(pId))
                {
                    aListaDepositos.Remove(DepositoAEliminar);
                    return true;
                }
            }
            return false;
        }

        public bool ModificarDeposito(int pId, string pNombre, string pDireccion, string pResponsable)
        {
            Deposito DepositoAModificar = BuscarDeposito(pId);
            if (DepositoAModificar != null)
            {
                DepositoAModificar.Nombre = pNombre;
                DepositoAModificar.Direccion = pDireccion;
                DepositoAModificar.Responsable = pResponsable;
                return true;
            }
            return false;
        }

        #endregion

        #region Equipamientos

        public int ProximoIdEquipamiento()
        {
            return Persistencia.ProximoEquipamientoId();
        }

        public List<Equipamiento> ListarEquipamientos()
        {
            aListaEquipamientos = Persistencia.ListaEquipamientos();
            return aListaEquipamientos;
        }

        public Equipamiento BuscarEquipamiento(int pId)
        {
            foreach (Equipamiento unEquipamiento in aListaEquipamientos)
            {
                if (unEquipamiento.Id == pId)
                {
                    return unEquipamiento;
                }
            }
            return null;
        }

        public bool AltaEquipamiento(Equipamiento pEquipamiento)
        {
            Equipamiento ComparoEquipamiento = BuscarEquipamiento(pEquipamiento.Id);
            if (ComparoEquipamiento == null)
            {
                if (Persistencia.AltaEquipamiento(pEquipamiento))
                {
                    aListaEquipamientos.Add(pEquipamiento);
                    return true;
                }
            }
            return false;
        }

        public bool BajaEquipamiento(int pId)
        {
            Equipamiento EquipamientoAEliminar = BuscarEquipamiento(pId);
            if (EquipamientoAEliminar != null)
            {
                if (Persistencia.BajaEquipamiento(pId))
                {
                    aListaEquipamientos.Remove(EquipamientoAEliminar);
                    return true;
                }
            }
            return false;
        }

        public bool ModificarEquipamiento(int pId, string pNombre, string pMarca, string pModelo,
                                          string pCaracteristicas, int pDepositoId,
                                          double pPrecioBaseAlquiler, string pCodigo,
                                          string pCategoria, string pEstado, int pStock)
        {
            Equipamiento EquipamientoAModificar = BuscarEquipamiento(pId);
            if (EquipamientoAModificar != null)
            {
                EquipamientoAModificar.Nombre = pNombre;
                EquipamientoAModificar.Marca = pMarca;
                EquipamientoAModificar.Modelo = pModelo;
                EquipamientoAModificar.Caracteristicas = pCaracteristicas;
                EquipamientoAModificar.DepositoId = pDepositoId;
                EquipamientoAModificar.PrecioBaseAlquiler = pPrecioBaseAlquiler;
                EquipamientoAModificar.Codigo = pCodigo;
                EquipamientoAModificar.Categoria = pCategoria;
                EquipamientoAModificar.Estado = pEstado;
                EquipamientoAModificar.Stock = pStock;
                return true;
            }
            return false;
        }

        #endregion

        #region Solicitudes

        public int ProximoIdSolicitud()
        {
            return Persistencia.ProximoSolicitudId();
        }

        public List<SolicitudAlquiler> ListarSolicitudes()
        {
            aListaSolicitudes = Persistencia.ListaSolicitudes();
            return aListaSolicitudes;
        }

        public SolicitudAlquiler BuscarSolicitud(int pId)
        {
            foreach (SolicitudAlquiler unaSolicitud in aListaSolicitudes)
            {
                if (unaSolicitud.Id == pId)
                {
                    return unaSolicitud;
                }
            }
            return null;
        }

        public bool AltaSolicitud(SolicitudAlquiler pSolicitud)
        {
            SolicitudAlquiler ComparoSolicitud = BuscarSolicitud(pSolicitud.Id);
            if (ComparoSolicitud == null)
            {
                if (Persistencia.AltaSolicitud(pSolicitud))
                {
                    aListaSolicitudes.Add(pSolicitud);
                    return true;
                }
            }
            return false;
        }

        public bool BajaSolicitud(int pId)
        {
            SolicitudAlquiler SolicitudAEliminar = BuscarSolicitud(pId);
            if (SolicitudAEliminar != null)
            {
                if (Persistencia.BajaSolicitud(pId))
                {
                    aListaSolicitudes.Remove(SolicitudAEliminar);
                    return true;
                }
            }
            return false;
        }

        public bool ModificarSolicitud(int pId, int pClienteId, string pTipoEvento,
                                        string pNombreEvento, DateTime pFechaInicio,
                                        DateTime pFechaFin, string pUbicacion,
                                        int pCantidadAsistentes, string pEstado)
        {
            SolicitudAlquiler SolicitudAModificar = BuscarSolicitud(pId);
            if (SolicitudAModificar != null)
            {
                SolicitudAModificar.ClienteId = pClienteId;
                SolicitudAModificar.TipoEvento = pTipoEvento;
                SolicitudAModificar.NombreEvento = pNombreEvento;
                SolicitudAModificar.FechaInicio = pFechaInicio;
                SolicitudAModificar.FechaFin = pFechaFin;
                SolicitudAModificar.Ubicacion = pUbicacion;
                SolicitudAModificar.CantidadAsistentes = pCantidadAsistentes;
                SolicitudAModificar.Estado = pEstado;
                return true;
            }
            return false;
        }

        #endregion

        #region LineasSolicitud

        public int ProximoIdLineaSolicitud()
        {
            return Persistencia.ProximoLineaSolicitudId();
        }

        public List<LineaSolicitud> ListarLineasSolicitud()
        {
            aListaLineasSolicitud = Persistencia.ListaLineasSolicitud();
            return aListaLineasSolicitud;
        }

        public List<LineaSolicitud> ListarLineasSolicitud(int pSolicitudId)
        {
            List<LineaSolicitud> ListaLineas = new List<LineaSolicitud>();
            foreach (LineaSolicitud unaLinea in aListaLineasSolicitud)
            {
                if (unaLinea.SolicitudId == pSolicitudId)
                {
                    ListaLineas.Add(unaLinea);
                }
            }
            return ListaLineas;
        }

        public LineaSolicitud BuscarLineaSolicitud(int pId)
        {
            foreach (LineaSolicitud unaLinea in aListaLineasSolicitud)
            {
                if (unaLinea.Id == pId)
                {
                    return unaLinea;
                }
            }
            return null;
        }

        public bool AltaLineaSolicitud(LineaSolicitud pLinea)
        {
            LineaSolicitud LineaExistente = BuscarLineaSolicitud(pLinea.Id);
            if (LineaExistente == null)
            {
                if (Persistencia.AltaLineaSolicitud(pLinea))
                {
                    aListaLineasSolicitud.Add(pLinea);
                    return true;
                }
            }
            return false;
        }

        public bool BajaLineaSolicitud(int pId)
        {
            LineaSolicitud LineaAEliminar = BuscarLineaSolicitud(pId);
            if (LineaAEliminar != null)
            {
                if (Persistencia.BajaLineaSolicitud(pId))
                {
                    aListaLineasSolicitud.Remove(LineaAEliminar);
                    return true;
                }
            }
            return false;
        }

        public void LimpiarLineasSolicitud()
        {
            aListaLineasSolicitud.Clear();
        }

        #endregion

        #region Contrataciones

        public int ProximoIdContratacion()
        {
            return Persistencia.ProximoContratacionId();
        }

        public List<Contratacion> ListarContrataciones()
        {
            aListaContrataciones = Persistencia.ListaContrataciones();
            return aListaContrataciones;
        }

        public Contratacion BuscarContratacion(int pId)
        {
            foreach (Contratacion unaContratacion in aListaContrataciones)
            {
                if (unaContratacion.Id == pId)
                {
                    return unaContratacion;
                }
            }
            return null;
        }

        public bool AltaContratacion(Contratacion pContratacion)
        {
            Contratacion ComparoContratacion = BuscarContratacion(pContratacion.Id);
            if (ComparoContratacion == null)
            {
                if (Persistencia.AltaContratacion(pContratacion))
                {
                    aListaContrataciones.Add(pContratacion);
                    return true;
                }
            }
            return false;
        }

        public bool BajaContratacion(int pId)
        {
            Contratacion ContratacionAEliminar = BuscarContratacion(pId);
            if (ContratacionAEliminar != null)
            {
                if (Persistencia.BajaContratacion(pId))
                {
                    aListaContrataciones.Remove(ContratacionAEliminar);
                    return true;
                }
            }
            return false;
        }

        public bool ModificarContratacion(int pId, DateTime pFechaInicio, DateTime pFechaFin,
                                           string pUbicacion, double pImporteTotal, string pEstado)
        {
            Contratacion ContratacionAModificar = BuscarContratacion(pId);
            if (ContratacionAModificar != null)
            {
                ContratacionAModificar.FechaInicio = pFechaInicio;
                ContratacionAModificar.FechaFin = pFechaFin;
                ContratacionAModificar.Ubicacion = pUbicacion;
                ContratacionAModificar.ImporteTotal = pImporteTotal;
                ContratacionAModificar.Estado = pEstado;
                return true;
            }
            return false;
        }

        #endregion

        #region LineasContratacion

        public int ProximoIdLineaContratacion()
        {
            return Persistencia.ProximoLineaContratacionId();
        }

        public List<LineaContratacion> ListarLineasContratacion()
        {
            aListaLineasContratacion = Persistencia.ListaLineasContratacion();
            return aListaLineasContratacion;
        }

        public List<LineaContratacion> ListarLineasContratacion(int pContratacionId)
        {
            List<LineaContratacion> ListaLineas = new List<LineaContratacion>();
            foreach (LineaContratacion unaLinea in aListaLineasContratacion)
            {
                if (unaLinea.ContratacionId == pContratacionId)
                {
                    ListaLineas.Add(unaLinea);
                }
            }
            return ListaLineas;
        }

        public LineaContratacion BuscarLineaContratacion(int pId)
        {
            foreach (LineaContratacion unaLinea in aListaLineasContratacion)
            {
                if (unaLinea.Id == pId)
                {
                    return unaLinea;
                }
            }
            return null;
        }

        public bool AltaLineaContratacion(LineaContratacion pLinea)
        {
            LineaContratacion LineaExistente = BuscarLineaContratacion(pLinea.Id);
            if (LineaExistente == null)
            {
                if (Persistencia.AltaLineaContratacion(pLinea))
                {
                    aListaLineasContratacion.Add(pLinea);
                    return true;
                }
            }
            return false;
        }

        public bool BajaLineaContratacion(int pId)
        {
            LineaContratacion LineaAEliminar = BuscarLineaContratacion(pId);
            if (LineaAEliminar != null)
            {
                if (Persistencia.BajaLineaContratacion(pId))
                {
                    aListaLineasContratacion.Remove(LineaAEliminar);
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Devoluciones

        public int ProximoIdDevolucion()
        {
            return Persistencia.ProximoDevolucionId();
        }

        public List<Devolucion> ListarDevoluciones()
        {
            aListaDevoluciones = Persistencia.ListaDevoluciones();
            return aListaDevoluciones;
        }

        public Devolucion BuscarDevolucion(int pId)
        {
            foreach (Devolucion unaDevolucion in aListaDevoluciones)
            {
                if (unaDevolucion.Id == pId)
                {
                    return unaDevolucion;
                }
            }
            return null;
        }

        public bool AltaDevolucion(Devolucion pDevolucion)
        {
            Devolucion ComparoDevolucion = BuscarDevolucion(pDevolucion.Id);
            if (ComparoDevolucion == null)
            {
                if (Persistencia.AltaDevolucion(pDevolucion))
                {
                    aListaDevoluciones.Add(pDevolucion);
                    return true;
                }
            }
            return false;
        }

        public bool BajaDevolucion(int pId)
        {
            Devolucion DevolucionAEliminar = BuscarDevolucion(pId);
            if (DevolucionAEliminar != null)
            {
                if (Persistencia.BajaDevolucion(pId))
                {
                    aListaDevoluciones.Remove(DevolucionAEliminar);
                    return true;
                }
            }
            return false;
        }

        public bool ModificarDevolucion(int pId, DateTime pFechaDevolucion,
                                         double pCargoAdicionalTotal, string pObservaciones)
        {
            Devolucion DevolucionAModificar = BuscarDevolucion(pId);
            if (DevolucionAModificar != null)
            {
                DevolucionAModificar.FechaDevolucion = pFechaDevolucion;
                DevolucionAModificar.CargoAdicionalTotal = pCargoAdicionalTotal;
                DevolucionAModificar.Observaciones = pObservaciones;
                return true;
            }
            return false;
        }

        #endregion

        #region DetallesDevolucion

        public int ProximoIdDetalleDevolucion()
        {
            return Persistencia.ProximoDetalleDevolucionId();
        }

        public List<DetalleDevolucion> ListarDetallesDevolucion()
        {
            aListaDetallesDevolucion = Persistencia.ListaDetallesDevolucion();
            return aListaDetallesDevolucion;
        }

        public List<DetalleDevolucion> ListarDetallesDevolucion(int pDevolucionId)
        {
            List<DetalleDevolucion> ListaDetalles = new List<DetalleDevolucion>();
            foreach (DetalleDevolucion unDetalle in aListaDetallesDevolucion)
            {
                if (unDetalle.DevolucionId == pDevolucionId)
                {
                    ListaDetalles.Add(unDetalle);
                }
            }
            return ListaDetalles;
        }

        public DetalleDevolucion BuscarDetalleDevolucion(int pId)
        {
            foreach (DetalleDevolucion unDetalle in aListaDetallesDevolucion)
            {
                if (unDetalle.Id == pId)
                {
                    return unDetalle;
                }
            }
            return null;
        }

        public bool AltaDetalleDevolucion(DetalleDevolucion pDetalle)
        {
            DetalleDevolucion DetalleExistente = BuscarDetalleDevolucion(pDetalle.Id);
            if (DetalleExistente == null)
            {
                if (Persistencia.AltaDetalleDevolucion(pDetalle))
                {
                    aListaDetallesDevolucion.Add(pDetalle);
                    return true;
                }
            }
            return false;
        }

        public bool BajaDetalleDevolucion(int pId)
        {
            DetalleDevolucion DetalleAEliminar = BuscarDetalleDevolucion(pId);
            if (DetalleAEliminar != null)
            {
                if (Persistencia.BajaDetalleDevolucion(pId))
                {
                    aListaDetallesDevolucion.Remove(DetalleAEliminar);
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Pagos

        public int ProximoIdPago()
        {
            return Persistencia.ProximoPagoId();
        }

        public List<Pago> ListarPagos()
        {
            aListaPagos = Persistencia.ListaPagos();
            return aListaPagos;
        }

        public List<Pago> ListarPagosPorContratacion(int pContratacionId)
        {
            List<Pago> ListaPagos = new List<Pago>();
            foreach (Pago unPago in aListaPagos)
            {
                if (unPago.ContratacionId == pContratacionId)
                {
                    ListaPagos.Add(unPago);
                }
            }
            return ListaPagos;
        }

        public Pago BuscarPago(int pId)
        {
            foreach (Pago unPago in aListaPagos)
            {
                if (unPago.Id == pId)
                {
                    return unPago;
                }
            }
            return null;
        }

        public bool AltaPago(Pago pPago)
        {
            Pago ComparoPago = BuscarPago(pPago.Id);
            if (ComparoPago == null)
            {
                if (Persistencia.AltaPago(pPago))
                {
                    aListaPagos.Add(pPago);
                    return true;
                }
            }
            return false;
        }

        public bool BajaPago(int pId)
        {
            Pago PagoAEliminar = BuscarPago(pId);
            if (PagoAEliminar != null)
            {
                if (Persistencia.BajaPago(pId))
                {
                    aListaPagos.Remove(PagoAEliminar);
                    return true;
                }
            }
            return false;
        }

        public bool ModificarPago(int pId, double pMonto, string pMetodoPago, string pObservacion)
        {
            Pago PagoAModificar = BuscarPago(pId);
            if (PagoAModificar != null)
            {
                PagoAModificar.Monto = pMonto;
                PagoAModificar.MetodoPago = pMetodoPago;
                PagoAModificar.Observacion = pObservacion;
                return true;
            }
            return false;
        }

        #endregion
    }
}