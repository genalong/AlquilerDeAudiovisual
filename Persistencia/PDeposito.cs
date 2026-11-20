using System.Data;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Persistencia
{
    public class PDeposito
    {
        private Conexion Conexion = new Conexion();

        public List<Deposito> ListaDepositos()
        {
            string sql = "SELECT * FROM Deposito";
            DataSet datos = Conexion.Consultar(sql);
            List<Deposito> lista = new List<Deposito>();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Deposito unDeposito = new Deposito(
                    int.Parse(fila[0].ToString()),
                    fila[1].ToString(),
                    fila[2].ToString(),
                    fila[3].ToString()
                );
                lista.Add(unDeposito);
            }
            return lista;
        }

        public bool Alta(Deposito unDeposito)
        {
            string sql = "INSERT INTO Deposito (Id, Nombre, Direccion, Responsable) "
                + "VALUES (" + unDeposito.Id + ",'" + unDeposito.Nombre + "','"
                + unDeposito.Direccion + "','" + unDeposito.Responsable + "')";

            return Conexion.Ejecutar(sql);
        }

        public bool Baja(int pId)
        {
            string sql = "DELETE FROM Deposito WHERE Id = " + pId.ToString();
            return Conexion.Ejecutar(sql);
        }

        public bool Modificar(Deposito unDeposito)
        {
            string sql = "UPDATE Deposito SET "
                + "Nombre = '" + unDeposito.Nombre + "',"
                + "Direccion = '" + unDeposito.Direccion + "',"
                + "Responsable = '" + unDeposito.Responsable + "' "
                + "WHERE Id = " + unDeposito.Id.ToString();

            return Conexion.Ejecutar(sql);
        }

        public int ProximoId()
        {
            string sql = "SELECT (ISNULL(MAX(Id),0)+1) FROM Deposito";
            DataSet datos = Conexion.Consultar(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            int Id = int.Parse(campo[0].ToString());
            return Id;
        }
    }
}