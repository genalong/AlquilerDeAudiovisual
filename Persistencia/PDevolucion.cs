using System.Data;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Persistencia
{
    public class PDevolucion
    {
        private Conexion Conexion = new Conexion();

        public List<Devolucion> ListaDevoluciones()
        {
            string sql = "SELECT * FROM Devolucion";
            DataSet datos = Conexion.Consultar(sql);
            List<Devolucion> lista = new List<Devolucion>();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Devolucion unaDevolucion = new Devolucion(
                    int.Parse(fila[0].ToString()),
                    int.Parse(fila[1].ToString()),
                    DateTime.Parse(fila[2].ToString()),
                    double.Parse(fila[3].ToString()),
                    fila[4].ToString()
                );
                lista.Add(unaDevolucion);
            }
            return lista;
        }

        public bool Alta(Devolucion unaDevolucion)
        {
            string sql = "INSERT INTO Devolucion (Id, ContratacionId, FechaDevolucion, CargoAdicionalTotal, Observaciones) "
                + "VALUES (" + unaDevolucion.Id + ","
                + unaDevolucion.ContratacionId + ",'"
                + unaDevolucion.FechaDevolucion.ToString("yyyy-MM-dd") + "',"
                + unaDevolucion.CargoAdicionalTotal + ",'"
                + unaDevolucion.Observaciones + "')";

            return Conexion.Ejecutar(sql);
        }

        public bool Baja(int pId)
        {
            string sql = "DELETE FROM Devolucion WHERE Id = " + pId.ToString();
            return Conexion.Ejecutar(sql);
        }

        public bool Modificar(Devolucion unaDevolucion)
        {
            string sql = "UPDATE Devolucion SET "
                + "FechaDevolucion = '" + unaDevolucion.FechaDevolucion.ToString("yyyy-MM-dd") + "',"
                + "CargoAdicionalTotal = " + unaDevolucion.CargoAdicionalTotal + ","
                + "Observaciones = '" + unaDevolucion.Observaciones + "' "
                + "WHERE Id = " + unaDevolucion.Id.ToString();

            return Conexion.Ejecutar(sql);
        }

        public int ProximoId()
        {
            string sql = "SELECT (ISNULL(MAX(Id),0)+1) FROM Devolucion";
            DataSet datos = Conexion.Consultar(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            int Id = int.Parse(campo[0].ToString());
            return Id;
        }
    }
}