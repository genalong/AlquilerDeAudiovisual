using System.Data;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Persistencia
{
    public class PPago
    {
        private Conexion Conexion = new Conexion();

        public List<Pago> ListaPagos()
        {
            string sql = "SELECT * FROM Pago";
            DataSet datos = Conexion.Consultar(sql);
            List<Pago> lista = new List<Pago>();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Pago unPago = new Pago(
                    int.Parse(fila[0].ToString()),
                    int.Parse(fila[1].ToString()),
                    DateTime.Parse(fila[2].ToString()),
                    double.Parse(fila[3].ToString()),
                    fila[4].ToString(),
                    fila[5].ToString()
                );
                lista.Add(unPago);
            }
            return lista;
        }

        public bool Alta(Pago unPago)
        {
            string sql = "INSERT INTO Pago (Id, ContratacionId, FechaPago, Monto, MetodoPago, Observacion) "
                + "VALUES (" + unPago.Id + ","
                + unPago.ContratacionId + ",'"
                + unPago.FechaPago.ToString("yyyy-MM-dd") + "',"
                + unPago.Monto + ",'"
                + unPago.MetodoPago + "','"
                + unPago.Observacion + "')";

            return Conexion.Ejecutar(sql);
        }

        public bool Baja(int pId)
        {
            string sql = "DELETE FROM Pago WHERE Id = " + pId.ToString();
            return Conexion.Ejecutar(sql);
        }

        public bool Modificar(Pago unPago)
        {
            string sql = "UPDATE Pago SET "
                + "Monto = " + unPago.Monto + ","
                + "MetodoPago = '" + unPago.MetodoPago + "',"
                + "Observacion = '" + unPago.Observacion + "' "
                + "WHERE Id = " + unPago.Id.ToString();

            return Conexion.Ejecutar(sql);
        }

        public int ProximoId()
        {
            string sql = "SELECT (ISNULL(MAX(Id),0)+1) FROM Pago";
            DataSet datos = Conexion.Consultar(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            int Id = int.Parse(campo[0].ToString());
            return Id;
        }
    }
}