using AlquilerAudiovisual.Persistencia;

namespace AlquilerAudiovisual.Dominio
{
    public class Controladora
    {
        private PControladora Persistencia;

        private static List<Cliente> aListaClientes = new List<Cliente>();
        private static List<Deposito> aListaDepositos = new List<Deposito>();
        private static List<Equipamiento> aListaEquipamientos = new List<Equipamiento>();
        private static List<Contratacion> aListaContrataciones = new List<Contratacion>();

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

        public bool ModificarContratacion(int pId, int pClienteId, int pEquipamientoId, int pCantidad,
                                           DateTime pFechaInicio, DateTime pFechaFin, string pUbicacion,
                                           double pImporteTotal, string pEstado)
        {
            Contratacion ContratacionAModificar = BuscarContratacion(pId);
            if (ContratacionAModificar != null)
            {
                ContratacionAModificar.ClienteId = pClienteId;
                ContratacionAModificar.EquipamientoId = pEquipamientoId;
                ContratacionAModificar.Cantidad = pCantidad;
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
    }
}