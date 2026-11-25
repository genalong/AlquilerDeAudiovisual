using System.Data;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Persistencia
{
    public class PCliente
    {
        private Conexion Conexion = new Conexion();

        public List<Cliente> ListaClientes()
        {
            string sql = "SELECT * FROM Cliente";
            DataSet datos = Conexion.Consultar(sql);
            List<Cliente> lista = new List<Cliente>();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Cliente unCliente = new Cliente(
                    int.Parse(fila[0].ToString()),
                    fila[1].ToString(),
                    fila[2].ToString(),
                    fila[3].ToString(),
                    fila[4].ToString(),
                    fila[5].ToString(),
                    fila[6].ToString(),
                    bool.Parse(fila[7].ToString())
                );
                lista.Add(unCliente);
            }
            return lista;
        }

        public bool Alta(Cliente unCliente)
        {
            string sql = "INSERT INTO Cliente (Id, Nombre, Tipo, Documento, Email, Telefono, Direccion, Activo) "
                + "VALUES (" + unCliente.Id + ",'" + unCliente.Nombre + "','" + unCliente.Tipo + "','"
                + unCliente.Documento + "','" + unCliente.Email + "','" + unCliente.Telefono + "','"
                + unCliente.Direccion + "'," + (unCliente.Activo ? 1 : 0) + ")";

            return Conexion.Ejecutar(sql);
        }

        public bool Baja(int pId)
        {
            string sql = "UPDATE Cliente SET Activo = 0 WHERE Id = " + pId.ToString();
            return Conexion.Ejecutar(sql);
        }

        public bool Modificar(Cliente unCliente)
        {
            string sql = "UPDATE Cliente SET "
                + "Nombre = '" + unCliente.Nombre + "',"
                + "Tipo = '" + unCliente.Tipo + "',"
                + "Documento = '" + unCliente.Documento + "',"
                + "Email = '" + unCliente.Email + "',"
                + "Telefono = '" + unCliente.Telefono + "',"
                + "Direccion = '" + unCliente.Direccion + "',"
                + "Activo = " + (unCliente.Activo ? 1 : 0)
                + " WHERE Id = " + unCliente.Id.ToString();

            return Conexion.Ejecutar(sql);
        }

        public int ProximoId()
        {
            string sql = "SELECT (ISNULL(MAX(Id),0)+1) FROM Cliente"; // <-- Paréntesis corregido acá
            DataSet datos = Conexion.Consultar(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            int Id = int.Parse(campo[0].ToString());
            return Id;
        }
    }
}