namespace AlquilerAudiovisual.Dominio
{
    public class Controladora
    {
        private static List<Cliente> aListaClientes = new List<Cliente>();
        private static List<Deposito> aListaDepositos = new List<Deposito>();
        private static List<Equipamiento> aListaEquipamientos = new List<Equipamiento>();
        private static List<SolicitudAlquiler> aListaSolicitudes = new List<SolicitudAlquiler>();
        private static List<LineaSolicitud> aListaDetallesSolicitud = new List<LineaSolicitud>();
        private static List<Contratacion> aListaContrataciones = new List<Contratacion>();
        private static List<LineaContratacion> aListaDetallesContratacion = new List<LineaContratacion>();
        private static List<Devolucion> aListaDevoluciones = new List<Devolucion>();
        private static List<DetalleDevolucion> aListaDetallesDevolucion = new List<DetalleDevolucion>();
        private static List<Pago> aListaPagos = new List<Pago>();

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

        public bool DesactivarCliente(int pId)
        {
            Cliente ClienteADesactivar = BuscarCliente(pId);

            if (ClienteADesactivar != null)
            {
                ClienteADesactivar.Activo = false;
                return true;
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
                EquipamientoAEliminar.Activo = false;
                return true;
            }
            return false;
        }

        public bool ModificarEquipamiento(int pId, string pNombre, string pMarca, string pModelo,
                                          string pCaracteristicas, int pDepositoId,
                                          double pPrecioBaseAlquiler, string pCodigo,
                                          string pEstado, int pStock)
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
                EquipamientoAModificar.Estado = pEstado;
                EquipamientoAModificar.Stock = pStock;
                return true;
            }
            return false;
        }

        #endregion


        #region SolicitudesAlquiler

        public List<SolicitudAlquiler> ListarSolicitudes()
        {
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
                aListaSolicitudes.Add(pSolicitud);
                LimpiarDetallesSolicitud();
                return true;
            }
            return false;
        }

        public bool BajaSolicitud(int pId)
        {
            SolicitudAlquiler SolicitudAEliminar = BuscarSolicitud(pId);

            if (SolicitudAEliminar != null)
            {
                aListaSolicitudes.Remove(SolicitudAEliminar);
                return true;
            }
            return false;
        }

        public bool ModificarSolicitud(int pId, int pClienteId, string pNombreEvento,
                                        DateTime pFechaEvento, string pUbicacion,
                                        string pHoraInicio, string pHoraFin,
                                        int pCantidadAsistentes, string pEstado)
        {
            SolicitudAlquiler SolicitudAModificar = BuscarSolicitud(pId);

            if (SolicitudAModificar != null)
            {
                SolicitudAModificar.ClienteId = pClienteId;
                SolicitudAModificar.NombreEvento = pNombreEvento;
                SolicitudAModificar.FechaEvento = pFechaEvento;
                SolicitudAModificar.Ubicacion = pUbicacion;
                SolicitudAModificar.HoraInicio = pHoraInicio;
                SolicitudAModificar.HoraFin = pHoraFin;
                SolicitudAModificar.CantidadAsistentes = pCantidadAsistentes;
                SolicitudAModificar.Estado = pEstado;
                return true;
            }
            return false;
        }

        public bool ModificarSolicitud(SolicitudAlquiler pSolicitud)
        {
            SolicitudAlquiler SolicitudAModificar = BuscarSolicitud(pSolicitud.Id);

            if (SolicitudAModificar != null)
            {
                SolicitudAModificar.ClienteId = pSolicitud.ClienteId;
                SolicitudAModificar.NombreEvento = pSolicitud.NombreEvento;
                SolicitudAModificar.FechaEvento = pSolicitud.FechaEvento;
                SolicitudAModificar.Ubicacion = pSolicitud.Ubicacion;
                SolicitudAModificar.HoraInicio = pSolicitud.HoraInicio;
                SolicitudAModificar.HoraFin = pSolicitud.HoraFin;
                SolicitudAModificar.CantidadAsistentes = pSolicitud.CantidadAsistentes;
                SolicitudAModificar.Estado = pSolicitud.Estado;
                return true;
            }
            return false;
        }

        #endregion


        #region DetallesSolicitud

        public List<LineaSolicitud> ListarDetallesSolicitud()
        {
            return aListaDetallesSolicitud;
        }

        public List<LineaSolicitud> ListarDetallesSolicitud(int pSolicitudId)
        {
            List<LineaSolicitud> ListaDetalles = new List<LineaSolicitud>();

            foreach (LineaSolicitud unDetalle in aListaDetallesSolicitud)
            {
                if (unDetalle.SolicitudId == pSolicitudId)
                {
                    ListaDetalles.Add(unDetalle);
                }
            }

            return ListaDetalles;
        }

        public LineaSolicitud BuscarDetalleSolicitud(int pId)
        {
            foreach (LineaSolicitud unDetalle in aListaDetallesSolicitud)
            {
                if (unDetalle.Id == pId)
                {
                    return unDetalle;
                }
            }
            return null;
        }

        public bool AltaDetalleSolicitud(LineaSolicitud pDetalle)
        {
            LineaSolicitud DetalleExistente = BuscarDetalleSolicitud(pDetalle.Id);

            if (DetalleExistente == null)
            {
                aListaDetallesSolicitud.Add(pDetalle);
                return true;
            }
            return false;
        }

        public bool BajaDetalleSolicitud(int pId)
        {
            LineaSolicitud DetalleAEliminar = BuscarDetalleSolicitud(pId);

            if (DetalleAEliminar != null)
            {
                aListaDetallesSolicitud.Remove(DetalleAEliminar);
                return true;
            }
            return false;
        }

        public void LimpiarDetallesSolicitud()
        {
            aListaDetallesSolicitud.Clear();
        }

        public bool ModificarDetalleSolicitud(int pId, int pCantidad)
        {
            LineaSolicitud DetalleAModificar = BuscarDetalleSolicitud(pId);

            if (DetalleAModificar != null)
            {
                DetalleAModificar.Cantidad = pCantidad;
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

        public bool ModificarContratacion(int pId, DateTime pFechaEvento, string pUbicacion,
                                           string pHoraInicio, string pHoraFin,
                                           double pImporteTotal, string pEstado)
        {
            Contratacion ContratacionAModificar = BuscarContratacion(pId);

            if (ContratacionAModificar != null)
            {
                ContratacionAModificar.FechaEvento = pFechaEvento;
                ContratacionAModificar.Ubicacion = pUbicacion;
                ContratacionAModificar.HoraInicio = pHoraInicio;
                ContratacionAModificar.HoraFin = pHoraFin;
                ContratacionAModificar.ImporteTotal = pImporteTotal;
                ContratacionAModificar.Estado = pEstado;
                return true;
            }
            return false;
        }

        public bool ModificarContratacion(Contratacion pContratacion)
        {
            Contratacion ContratacionAModificar = BuscarContratacion(pContratacion.Id);

            if (ContratacionAModificar != null)
            {
                ContratacionAModificar.SolicitudId = pContratacion.SolicitudId;
                ContratacionAModificar.ClienteId = pContratacion.ClienteId;
                ContratacionAModificar.FechaEvento = pContratacion.FechaEvento;
                ContratacionAModificar.Ubicacion = pContratacion.Ubicacion;
                ContratacionAModificar.HoraInicio = pContratacion.HoraInicio;
                ContratacionAModificar.HoraFin = pContratacion.HoraFin;
                ContratacionAModificar.ImporteTotal = pContratacion.ImporteTotal;
                ContratacionAModificar.Estado = pContratacion.Estado;
                return true;
            }
            return false;
        }

        #endregion


        #region DetallesContratacion

        public List<LineaContratacion> ListarDetallesContratacion()
        {
            return aListaDetallesContratacion;
        }

        public List<LineaContratacion> ListarDetallesContratacion(int pContratacionId)
        {
            List<LineaContratacion> ListaDetalles = new List<LineaContratacion>();

            foreach (LineaContratacion unDetalle in aListaDetallesContratacion)
            {
                if (unDetalle.ContratacionId == pContratacionId)
                {
                    ListaDetalles.Add(unDetalle);
                }
            }

            return ListaDetalles;
        }

        public LineaContratacion BuscarDetalleContratacion(int pId)
        {
            foreach (LineaContratacion unDetalle in aListaDetallesContratacion)
            {
                if (unDetalle.Id == pId)
                {
                    return unDetalle;
                }
            }
            return null;
        }

        public bool AltaDetalleContratacion(LineaContratacion pDetalle)
        {
            LineaContratacion DetalleExistente = BuscarDetalleContratacion(pDetalle.Id);

            if (DetalleExistente == null)
            {
                aListaDetallesContratacion.Add(pDetalle);
                return true;
            }
            return false;
        }

        public bool BajaDetalleContratacion(int pId)
        {
            LineaContratacion DetalleAEliminar = BuscarDetalleContratacion(pId);

            if (DetalleAEliminar != null)
            {
                aListaDetallesContratacion.Remove(DetalleAEliminar);
                return true;
            }
            return false;
        }

        public bool ModificarDetalleContratacion(int pId, int pCantidad, double pPrecioUnitario)
        {
            LineaContratacion DetalleAModificar = BuscarDetalleContratacion(pId);

            if (DetalleAModificar != null)
            {
                DetalleAModificar.Cantidad = pCantidad;
                DetalleAModificar.PrecioUnitario = pPrecioUnitario;
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

                Contratacion laContratacion = BuscarContratacion(pDevolucion.ContratacionId);

                if (laContratacion != null)
                {
                    laContratacion.Estado = "Finalizada";
                }

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

        public List<DetalleDevolucion> ListarDetallesDevolucion()
        {
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
                aListaDetallesDevolucion.Add(pDetalle);
                return true;
            }
            return false;
        }

        public bool BajaDetalleDevolucion(int pId)
        {
            DetalleDevolucion DetalleAEliminar = BuscarDetalleDevolucion(pId);

            if (DetalleAEliminar != null)
            {
                aListaDetallesDevolucion.Remove(DetalleAEliminar);
                return true;
            }
            return false;
        }

        public bool ModificarDetalleDevolucion(int pId, int pCantidad,
                                               string pTipoIncidencia,
                                               double pCargoAdicional,
                                               string pObservacion)
        {
            DetalleDevolucion DetalleAModificar = BuscarDetalleDevolucion(pId);

            if (DetalleAModificar != null)
            {
                DetalleAModificar.Cantidad = pCantidad;
                DetalleAModificar.TipoIncidencia = pTipoIncidencia;
                DetalleAModificar.CargoAdicional = pCargoAdicional;
                DetalleAModificar.Observacion = pObservacion;
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

        public List<Pago> ListarPagosPorContratacion(int pContratacionId)
        {
            List<Pago> PagosDeContratacion = new List<Pago>();

            foreach (Pago unPago in aListaPagos)
            {
                if (unPago.ContratacionId == pContratacionId)
                {
                    PagosDeContratacion.Add(unPago);
                }
            }

            return PagosDeContratacion;
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


        #region Logica de negocio

        public bool HayDisponibilidad(int pEquipamientoId, DateTime pFecha, int pCantidad)
        {
            Equipamiento elEquipamiento = BuscarEquipamiento(pEquipamientoId);

            if (elEquipamiento == null || !elEquipamiento.Activo)
            {
                return false;
            }

            if (elEquipamiento.Estado == "Fuera de servicio")
            {
                return false;
            }

            int comprometido = CantidadComprometida(pEquipamientoId, pFecha);
            int enMantenimiento = 0;

            if (elEquipamiento.Estado == "En mantenimiento")
            {
                enMantenimiento = elEquipamiento.Stock;
            }

            int disponible = elEquipamiento.Stock - enMantenimiento - comprometido;

            return disponible >= pCantidad;
        }

        public int CantidadComprometida(int pEquipamientoId, DateTime pFecha)
        {
            int total = 0;

            foreach (Contratacion unaContratacion in aListaContrataciones)
            {
                if (unaContratacion.Estado == "Cancelada" || unaContratacion.Estado == "Finalizada")
                {
                    continue;
                }

                if (unaContratacion.FechaEvento.Date != pFecha.Date)
                {
                    continue;
                }

                foreach (LineaContratacion unDetalle in aListaDetallesContratacion)
                {
                    if (unDetalle.ContratacionId == unaContratacion.Id &&
                        unDetalle.EquipamientoId == pEquipamientoId)
                    {
                        total = total + unDetalle.Cantidad;
                    }
                }
            }

            return total;
        }

        public int AceptarSolicitud(int pSolicitudId)
        {
            SolicitudAlquiler laSolicitud = BuscarSolicitud(pSolicitudId);

            if (laSolicitud == null || laSolicitud.Estado != "Pendiente")
            {
                return -2;
            }

            List<LineaSolicitud> Detalles = ListarDetallesSolicitud(pSolicitudId);

            if (Detalles.Count == 0)
            {
                return -2;
            }

            foreach (LineaSolicitud unDetalle in Detalles)
            {
                if (!HayDisponibilidad(unDetalle.EquipamientoId, laSolicitud.FechaEvento, unDetalle.Cantidad))
                {
                    return -1;
                }
            }

            int NuevoIdContratacion = 1;
            foreach (Contratacion unaContratacion in aListaContrataciones)
            {
                if (unaContratacion.Id >= NuevoIdContratacion)
                {
                    NuevoIdContratacion = unaContratacion.Id + 1;
                }
            }

            Contratacion laContratacion = new Contratacion(
                NuevoIdContratacion,
                laSolicitud.Id,
                laSolicitud.ClienteId,
                laSolicitud.FechaEvento,
                laSolicitud.Ubicacion,
                laSolicitud.HoraInicio,
                laSolicitud.HoraFin,
                0,
                "En preparación"
            );

            if (!AltaContratacion(laContratacion))
            {
                return -3;
            }

            double Total = 0;
            int NuevoIdDetalle = 1;

            foreach (LineaContratacion unDetalleExistente in aListaDetallesContratacion)
            {
                if (unDetalleExistente.Id >= NuevoIdDetalle)
                {
                    NuevoIdDetalle = unDetalleExistente.Id + 1;
                }
            }

            foreach (LineaSolicitud unDetalleSolicitud in Detalles)
            {
                Equipamiento elEquipamiento = BuscarEquipamiento(unDetalleSolicitud.EquipamientoId);
                double PrecioUnitario = 0;

                if (elEquipamiento != null)
                {
                    PrecioUnitario = elEquipamiento.PrecioBaseAlquiler;
                }

                LineaContratacion unDetalle = new LineaContratacion(
                    NuevoIdDetalle,
                    laContratacion.Id,
                    unDetalleSolicitud.EquipamientoId,
                    unDetalleSolicitud.Cantidad,
                    PrecioUnitario
                );

                AltaDetalleContratacion(unDetalle);
                Total = Total + (unDetalleSolicitud.Cantidad * PrecioUnitario);
                NuevoIdDetalle++;
            }

            laContratacion.ImporteTotal = Total;
            laSolicitud.Estado = "Aceptada";

            return laContratacion.Id;
        }

        public double SaldoPendiente(int pContratacionId)
        {
            Contratacion laContratacion = BuscarContratacion(pContratacionId);

            if (laContratacion == null)
            {
                return 0;
            }

            double TotalPagado = 0;
            List<Pago> PagosDeContratacion = ListarPagosPorContratacion(pContratacionId);

            foreach (Pago unPago in PagosDeContratacion)
            {
                TotalPagado = TotalPagado + unPago.Monto;
            }

            return laContratacion.ImporteTotal - TotalPagado;
        }

        public List<string[]> ReporteMasAlquilado()
        {
            List<string[]> Resultado = new List<string[]>();

            foreach (Equipamiento unEquipamiento in aListaEquipamientos)
            {
                int UnidadesAlquiladas = 0;
                int CantidadContrataciones = 0;

                foreach (Contratacion unaContratacion in aListaContrataciones)
                {
                    if (unaContratacion.Estado == "Cancelada")
                    {
                        continue;
                    }

                    bool Participo = false;

                    foreach (LineaContratacion unDetalle in aListaDetallesContratacion)
                    {
                        if (unDetalle.ContratacionId == unaContratacion.Id &&
                            unDetalle.EquipamientoId == unEquipamiento.Id)
                        {
                            UnidadesAlquiladas = UnidadesAlquiladas + unDetalle.Cantidad;
                            Participo = true;
                        }
                    }

                    if (Participo)
                    {
                        CantidadContrataciones++;
                    }
                }

                if (UnidadesAlquiladas > 0)
                {
                    Resultado.Add(new string[] {
                        unEquipamiento.Nombre,
                        UnidadesAlquiladas.ToString(),
                        CantidadContrataciones.ToString()
                    });
                }
            }

            return Resultado;
        }

        public List<string[]> ReporteDisponibilidad(DateTime pFecha)
        {
            List<string[]> Resultado = new List<string[]>();

            foreach (Equipamiento unEquipamiento in aListaEquipamientos)
            {
                if (!unEquipamiento.Activo)
                {
                    continue;
                }

                int Comprometido = CantidadComprometida(unEquipamiento.Id, pFecha);
                int Disponible = unEquipamiento.Stock - Comprometido;
                Deposito elDeposito = BuscarDeposito(unEquipamiento.DepositoId);

                string NombreDeposito = "(sin depósito)";

                if (elDeposito != null)
                {
                    NombreDeposito = elDeposito.Nombre;
                }

                Resultado.Add(new string[] {
                    NombreDeposito,
                    unEquipamiento.Nombre,
                    unEquipamiento.Stock.ToString(),
                    Comprometido.ToString(),
                    Disponible.ToString()
                });
            }

            return Resultado;
        }

        public List<string[]> ReporteContratacionesPorCliente(DateTime pDesde, DateTime pHasta)
        {
            List<string[]> Resultado = new List<string[]>();

            foreach (Cliente unCliente in aListaClientes)
            {
                int Cantidad = 0;
                double ImporteTotal = 0;

                foreach (Contratacion unaContratacion in aListaContrataciones)
                {
                    if (unaContratacion.ClienteId != unCliente.Id)
                    {
                        continue;
                    }

                    if (unaContratacion.FechaEvento.Date < pDesde.Date ||
                        unaContratacion.FechaEvento.Date > pHasta.Date)
                    {
                        continue;
                    }

                    Cantidad++;
                    ImporteTotal = ImporteTotal + unaContratacion.ImporteTotal;
                }

                if (Cantidad > 0)
                {
                    Resultado.Add(new string[] {
                        unCliente.Nombre,
                        Cantidad.ToString(),
                        ImporteTotal.ToString("0.00")
                    });
                }
            }

            return Resultado;
        }

        public List<string[]> ReporteCuentasPorCobrar()
        {
            List<string[]> Resultado = new List<string[]>();

            foreach (Contratacion unaContratacion in aListaContrataciones)
            {
                if (unaContratacion.Estado == "Cancelada")
                {
                    continue;
                }

                Cliente elCliente = BuscarCliente(unaContratacion.ClienteId);

                string NombreCliente = "(desconocido)";

                if (elCliente != null)
                {
                    NombreCliente = elCliente.Nombre;
                }

                double TotalPagado = 0;
                List<Pago> PagosDeContratacion = ListarPagosPorContratacion(unaContratacion.Id);

                foreach (Pago unPago in PagosDeContratacion)
                {
                    TotalPagado = TotalPagado + unPago.Monto;
                }

                double Saldo = unaContratacion.ImporteTotal - TotalPagado;

                Resultado.Add(new string[] {
                    unaContratacion.Id.ToString(),
                    NombreCliente,
                    unaContratacion.ImporteTotal.ToString("0.00"),
                    TotalPagado.ToString("0.00"),
                    Saldo.ToString("0.00")
                });
            }

            return Resultado;
        }

        public List<string[]> ReporteIncidencias()
        {
            List<string[]> Resultado = new List<string[]>();

            foreach (DetalleDevolucion unDetalle in aListaDetallesDevolucion)
            {
                if (unDetalle.TipoIncidencia == "Correcta")
                {
                    continue;
                }

                Equipamiento elEquipamiento = BuscarEquipamiento(unDetalle.EquipamientoId);

                string NombreEquipamiento = "(desconocido)";

                if (elEquipamiento != null)
                {
                    NombreEquipamiento = elEquipamiento.Nombre;
                }

                Resultado.Add(new string[] {
                    NombreEquipamiento,
                    unDetalle.Cantidad.ToString(),
                    unDetalle.TipoIncidencia,
                    unDetalle.CargoAdicional.ToString("0.00")
                });
            }

            return Resultado;
        }

        #endregion
    }
}