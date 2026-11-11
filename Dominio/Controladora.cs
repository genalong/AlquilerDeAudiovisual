
namespace AlquilerAudiovisual.Dominio
{
    public class Controladora
    {
        private static List<Cliente> aListaClientes = new List<Cliente>();
        private static List<Evento> aListaEventos = new List<Evento>();
        private static List<Solicitud> aListaSolicitudes = new List<Solicitud>();
        private static List<Contratacion> aListaContrataciones = new List<Contratacion>();
        private static List<Equipamiento> aListaEquipamientos = new List<Equipamiento>();
        private static List<Deposito> aListaDepositos = new List<Deposito>();
        private static List<EquipoIndividual> aListaEquiposIndividuales = new List<EquipoIndividual>();
        private static List<StockEquipamiento> aListaStockEquipamientos = new List<StockEquipamiento>();
        private static List<DetalleSolicitud> aListaDetallesSolicitud = new List<DetalleSolicitud>();
        private static List<DetalleContratacion> aListaDetallesContratacion = new List<DetalleContratacion>();
        private static List<Pago> aListaPagos = new List<Pago>();
        private static List<Devolucion> aListaDevoluciones = new List<Devolucion>();
        private static List<DetalleDevolucion> aListaDetallesDevolucion = new List<DetalleDevolucion>();
        private static List<Incidencia> aListaIncidencias = new List<Incidencia>();


        #region Clientes

        public List<Cliente> ListarClientes()
        {
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
                aListaClientes.Add(pCliente);
                return true;
            }
            return false;
        }

        public bool BajaCliente(int pId)
        {
            Cliente ClienteAEliminar = BuscarCliente(pId);

            if (ClienteAEliminar != null)
            {
                aListaClientes.Remove(ClienteAEliminar);
                return true;
            }
            return false;
        }

        public bool ModificarCliente(int pId, string pNombre, string pTelefono, string pDireccion, string pEmail)
        {
            Cliente ClienteAModificar = BuscarCliente(pId);

            if (ClienteAModificar != null)
            {
                ClienteAModificar.Nombre = pNombre;
                ClienteAModificar.Telefono = pTelefono;
                ClienteAModificar.Direccion = pDireccion;
                ClienteAModificar.Email = pEmail;
                return true;
            }
            return false;
        }

        #endregion


        #region Eventos

        public List<Evento> ListarEventos()
        {
            return aListaEventos;
        }

        public Evento BuscarEvento(int pId)
        {
            foreach (Evento unEvento in aListaEventos)
            {
                if (unEvento.Id == pId)
                {
                    return unEvento;
                }
            }
            return null;
        }

        public bool AltaEvento(Evento pEvento)
        {
            Evento ComparoEvento = BuscarEvento(pEvento.Id);

            if (ComparoEvento == null)
            {
                aListaEventos.Add(pEvento);
                return true;
            }
            return false;
        }

        public bool BajaEvento(int pId)
        {
            Evento EventoAEliminar = BuscarEvento(pId);

            if (EventoAEliminar != null)
            {
                aListaEventos.Remove(EventoAEliminar);
                return true;
            }
            return false;
        }

        public bool ModificarEvento(int pId, string pTipo, DateTime pFecha)
        {
            Evento EventoAModificar = BuscarEvento(pId);

            if (EventoAModificar != null)
            {
                EventoAModificar.Tipo = pTipo;
                EventoAModificar.Fecha = pFecha;
                return true;
            }
            return false;
        }

        #endregion


        #region Solicitudes

        public List<Solicitud> ListarSolicitudes()
        {
            return aListaSolicitudes;
        }

        public Solicitud BuscarSolicitud(int pId)
        {
            foreach (Solicitud unaSolicitud in aListaSolicitudes)
            {
                if (unaSolicitud.Id == pId)
                {
                    return unaSolicitud;
                }
            }
            return null;
        }

        public bool AltaSolicitud(Solicitud pSolicitud)
        {
            Solicitud ComparoSolicitud = BuscarSolicitud(pSolicitud.Id);

            if (ComparoSolicitud == null)
            {
                aListaSolicitudes.Add(pSolicitud);
                return true;
            }
            return false;
        }

        public bool BajaSolicitud(int pId)
        {
            Solicitud SolicitudAEliminar = BuscarSolicitud(pId);

            if (SolicitudAEliminar != null)
            {
                aListaSolicitudes.Remove(SolicitudAEliminar);
                return true;
            }
            return false;
        }

        public bool ModificarSolicitud(int pId, string pEstado)
        {
            Solicitud SolicitudAModificar = BuscarSolicitud(pId);

            if (SolicitudAModificar != null)
            {
                SolicitudAModificar.Estado = pEstado;
                return true;
            }
            return false;
        }

        #endregion


        #region Contrataciones

        public List<Contratacion> ListarContrataciones()
        {
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
                aListaContrataciones.Add(pContratacion);
                return true;
            }
            return false;
        }

        public bool BajaContratacion(int pId)
        {
            Contratacion ContratacionAEliminar = BuscarContratacion(pId);

            if (ContratacionAEliminar != null)
            {
                aListaContrataciones.Remove(ContratacionAEliminar);
                return true;
            }
            return false;
        }

        public bool ModificarContratacion(int pId, DateTime pFecha, double pTotal, string pEstado)
        {
            Contratacion ContratacionAModificar = BuscarContratacion(pId);

            if (ContratacionAModificar != null)
            {
                ContratacionAModificar.Fecha = pFecha;
                ContratacionAModificar.Total = pTotal;
                ContratacionAModificar.Estado = pEstado;
                return true;
            }
            return false;
        }

        #endregion


        #region Equipamientos

        public List<Equipamiento> ListarEquipamientos()
        {
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
                aListaEquipamientos.Add(pEquipamiento);
                return true;
            }
            return false;
        }

        public bool BajaEquipamiento(int pId)
        {
            Equipamiento EquipamientoAEliminar = BuscarEquipamiento(pId);

            if (EquipamientoAEliminar != null)
            {
                aListaEquipamientos.Remove(EquipamientoAEliminar);
                return true;
            }
            return false;
        }

        public bool ModificarEquipamiento(int pId, string pNombre, string pTipo, double pPrecioAlquiler)
        {
            Equipamiento EquipamientoAModificar = BuscarEquipamiento(pId);

            if (EquipamientoAModificar != null)
            {
                EquipamientoAModificar.Nombre = pNombre;
                EquipamientoAModificar.Tipo = pTipo;
                EquipamientoAModificar.PrecioAlquiler = pPrecioAlquiler;
                return true;
            }
            return false;
        }

        #endregion


        #region Depositos

        public List<Deposito> ListarDepositos()
        {
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
                aListaDepositos.Add(pDeposito);
                return true;
            }
            return false;
        }

        public bool BajaDeposito(int pId)
        {
            Deposito DepositoAEliminar = BuscarDeposito(pId);

            if (DepositoAEliminar != null)
            {
                aListaDepositos.Remove(DepositoAEliminar);
                return true;
            }
            return false;
        }

        public bool ModificarDeposito(int pId, string pNombre, string pDireccion)
        {
            Deposito DepositoAModificar = BuscarDeposito(pId);

            if (DepositoAModificar != null)
            {
                DepositoAModificar.Nombre = pNombre;
                DepositoAModificar.Direccion = pDireccion;
                return true;
            }
            return false;
        }

        #endregion


        #region EquiposIndividuales

        public List<EquipoIndividual> ListarEquiposIndividuales()
        {
            return aListaEquiposIndividuales;
        }

        public EquipoIndividual BuscarEquipoIndividual(int pId)
        {
            foreach (EquipoIndividual unEquipo in aListaEquiposIndividuales)
            {
                if (unEquipo.Id == pId)
                {
                    return unEquipo;
                }
            }
            return null;
        }

        public bool AltaEquipoIndividual(EquipoIndividual pEquipo)
        {
            EquipoIndividual ComparoEquipo = BuscarEquipoIndividual(pEquipo.Id);

            if (ComparoEquipo == null)
            {
                aListaEquiposIndividuales.Add(pEquipo);
                return true;
            }
            return false;
        }

        public bool BajaEquipoIndividual(int pId)
        {
            EquipoIndividual EquipoAEliminar = BuscarEquipoIndividual(pId);

            if (EquipoAEliminar != null)
            {
                aListaEquiposIndividuales.Remove(EquipoAEliminar);
                return true;
            }
            return false;
        }

        public bool ModificarEquipoIndividual(int pId, string pNumeroSerie, string pEstado)
        {
            EquipoIndividual EquipoAModificar = BuscarEquipoIndividual(pId);

            if (EquipoAModificar != null)
            {
                EquipoAModificar.NumeroSerie = pNumeroSerie;
                EquipoAModificar.Estado = pEstado;
                return true;
            }
            return false;
        }

        #endregion


        #region StockEquipamientos

        public List<StockEquipamiento> ListarStockEquipamientos()
        {
            return aListaStockEquipamientos;
        }

        public StockEquipamiento BuscarStockEquipamiento(Equipamiento pEquipamiento, Deposito pDeposito)
        {
            foreach (StockEquipamiento unStock in aListaStockEquipamientos)
            {
                if (unStock.Equipamiento == pEquipamiento && unStock.Deposito == pDeposito)
                {
                    return unStock;
                }
            }
            return null;
        }

        public bool AltaStockEquipamiento(StockEquipamiento pStock)
        {
            StockEquipamiento StockExistente = BuscarStockEquipamiento(pStock.Equipamiento, pStock.Deposito);

            if (StockExistente == null)
            {
                aListaStockEquipamientos.Add(pStock);
                return true;
            }
            return false;
        }

        public bool BajaStockEquipamiento(Equipamiento pEquipamiento, Deposito pDeposito)
        {
            StockEquipamiento StockAEliminar = BuscarStockEquipamiento(pEquipamiento, pDeposito);

            if (StockAEliminar != null)
            {
                aListaStockEquipamientos.Remove(StockAEliminar);
                return true;
            }
            return false;
        }

        public bool ModificarStockEquipamiento(Equipamiento pEquipamiento, Deposito pDeposito, int pCantidadTotal, int pCantidadDisponible)
        {
            StockEquipamiento StockAModificar = BuscarStockEquipamiento(pEquipamiento, pDeposito);

            if (StockAModificar != null)
            {
                StockAModificar.CantidadTotal = pCantidadTotal;
                StockAModificar.CantidadDisponible = pCantidadDisponible;
                return true;
            }
            return false;
        }

        #endregion


        #region DetallesSolicitud

        public List<DetalleSolicitud> ListarDetallesSolicitud()
        {
            return aListaDetallesSolicitud;
        }

        public DetalleSolicitud BuscarDetalleSolicitud(int pId)
        {
            foreach (DetalleSolicitud unDetalle in aListaDetallesSolicitud)
            {
                if (unDetalle.Id == pId)
                {
                    return unDetalle;
                }
            }
            return null;
        }

        public bool AltaDetalleSolicitud(DetalleSolicitud pDetalle)
        {
            DetalleSolicitud DetalleExistente = BuscarDetalleSolicitud(pDetalle.Id);

            if (DetalleExistente == null)
            {
                aListaDetallesSolicitud.Add(pDetalle);
                return true;
            }
            return false;
        }

        public bool BajaDetalleSolicitud(int pId)
        {
            DetalleSolicitud DetalleAEliminar = BuscarDetalleSolicitud(pId);

            if (DetalleAEliminar != null)
            {
                aListaDetallesSolicitud.Remove(DetalleAEliminar);
                return true;
            }
            return false;
        }

        public bool ModificarDetalleSolicitud(int pId, int pCantidad, double pPrecioEstimado)
        {
            DetalleSolicitud DetalleAModificar = BuscarDetalleSolicitud(pId);

            if (DetalleAModificar != null)
            {
                DetalleAModificar.Cantidad = pCantidad;
                DetalleAModificar.PrecioEstimado = pPrecioEstimado;
                return true;
            }
            return false;
        }

        #endregion


        #region DetallesContratacion

        public List<DetalleContratacion> ListarDetallesContratacion()
        {
            return aListaDetallesContratacion;
        }

        public DetalleContratacion BuscarDetalleContratacion(int pId)
        {
            foreach (DetalleContratacion unDetalle in aListaDetallesContratacion)
            {
                if (unDetalle.Id == pId)
                {
                    return unDetalle;
                }
            }
            return null;
        }

        public bool AltaDetalleContratacion(DetalleContratacion pDetalle)
        {
            DetalleContratacion DetalleExistente = BuscarDetalleContratacion(pDetalle.Id);

            if (DetalleExistente == null)
            {
                aListaDetallesContratacion.Add(pDetalle);
                return true;
            }
            return false;
        }

        public bool BajaDetalleContratacion(int pId)
        {
            DetalleContratacion DetalleAEliminar = BuscarDetalleContratacion(pId);

            if (DetalleAEliminar != null)
            {
                aListaDetallesContratacion.Remove(DetalleAEliminar);
                return true;
            }
            return false;
        }

        public bool ModificarDetalleContratacion(int pId, int pCantidad, double pPrecioAcordado)
        {
            DetalleContratacion DetalleAModificar = BuscarDetalleContratacion(pId);

            if (DetalleAModificar != null)
            {
                DetalleAModificar.Cantidad = pCantidad;
                DetalleAModificar.PrecioAcordado = pPrecioAcordado;
                return true;
            }
            return false;
        }

        #endregion


        #region Pagos

        public List<Pago> ListarPagos()
        {
            return aListaPagos;
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
            Pago PagoExistente = BuscarPago(pPago.Id);

            if (PagoExistente == null)
            {
                aListaPagos.Add(pPago);
                return true;
            }
            return false;
        }

        public bool BajaPago(int pId)
        {
            Pago PagoAEliminar = BuscarPago(pId);

            if (PagoAEliminar != null)
            {
                aListaPagos.Remove(PagoAEliminar);
                return true;
            }
            return false;
        }

        public bool ModificarPago(int pId, double pImporte, string pMetodo)
        {
            Pago PagoAModificar = BuscarPago(pId);

            if (PagoAModificar != null)
            {
                PagoAModificar.Importe = pImporte;
                PagoAModificar.Metodo = pMetodo;
                return true;
            }
            return false;
        }

        #endregion


        #region Devoluciones

        public List<Devolucion> ListarDevoluciones()
        {
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
            Devolucion DevolucionExistente = BuscarDevolucion(pDevolucion.Id);

            if (DevolucionExistente == null)
            {
                aListaDevoluciones.Add(pDevolucion);
                return true;
            }
            return false;
        }

        public bool BajaDevolucion(int pId)
        {
            Devolucion DevolucionAEliminar = BuscarDevolucion(pId);

            if (DevolucionAEliminar != null)
            {
                aListaDevoluciones.Remove(DevolucionAEliminar);
                return true;
            }
            return false;
        }

        public bool ModificarDevolucion(int pId, DateTime pFecha, string pObservacion)
        {
            Devolucion DevolucionAModificar = BuscarDevolucion(pId);

            if (DevolucionAModificar != null)
            {
                DevolucionAModificar.Fecha = pFecha;
                DevolucionAModificar.Observacion = pObservacion;
                return true;
            }
            return false;
        }

        #endregion

        #region DetallesDevolucion

        public List<DetalleDevolucion> ListarDetallesDevolucion()
        {
            return aListaDetallesDevolucion;
        }

        public bool AltaDetalleDevolucion(DetalleDevolucion pDetalle)
        {
            if (pDetalle != null)
            {
                aListaDetallesDevolucion.Add(pDetalle);
                return true;
            }
            return false;
        }

        public bool BajaDetalleDevolucion(DetalleDevolucion pDetalle)
        {
            if (aListaDetallesDevolucion.Contains(pDetalle))
            {
                aListaDetallesDevolucion.Remove(pDetalle);
                return true;
            }
            return false;
        }

        public bool ModificarDetalleDevolucion(DetalleDevolucion pDetalle, int pCantidadDevuelta, string pEstado)
        {
            if (aListaDetallesDevolucion.Contains(pDetalle))
            {
                pDetalle.CantidadDevuelta = pCantidadDevuelta;
                pDetalle.Estado = pEstado;
                return true;
            }
            return false;
        }

        #endregion

        #region Incidencias

        public List<Incidencia> ListarIncidencias()
        {
            return aListaIncidencias;
        }

        public Incidencia BuscarIncidencia(int pId)
        {
            foreach (Incidencia unaIncidencia in aListaIncidencias)
            {
                if (unaIncidencia.Id == pId)
                {
                    return unaIncidencia;
                }
            }
            return null;
        }

        public bool AltaIncidencia(Incidencia pIncidencia)
        {
            Incidencia IncidenciaExistente = BuscarIncidencia(pIncidencia.Id);

            if (IncidenciaExistente == null)
            {
                aListaIncidencias.Add(pIncidencia);
                return true;
            }
            return false;
        }

        public bool BajaIncidencia(int pId)
        {
            Incidencia IncidenciaAEliminar = BuscarIncidencia(pId);

            if (IncidenciaAEliminar != null)
            {
                aListaIncidencias.Remove(IncidenciaAEliminar);
                return true;
            }
            return false;
        }

        public bool ModificarIncidencia(int pId, string pDescripcion, double pCosto)
        {
            Incidencia IncidenciaAModificar = BuscarIncidencia(pId);

            if (IncidenciaAModificar != null)
            {
                IncidenciaAModificar.Descripcion = pDescripcion;
                IncidenciaAModificar.Costo = pCosto;
                return true;
            }
            return false;
        }

        #endregion
    }
}