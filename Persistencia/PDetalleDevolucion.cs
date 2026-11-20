using System.Data;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Persistencia
{
    public class PDetalleDevolucion
    {
        private Conexion Conexion = new Conexion();

        public List<DetalleDevolucion> ListaDetallesDevolucion()
        {
            string sql = "SELECT * FROM DetalleDevolucion";
            DataSet datos = Conexion.Consultar(sql);
            List<DetalleDevolucion> lista = new List<DetalleDevolucion>();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                DetalleDevolucion unDetalle = new DetalleDevolucion(
                    int.Parse(fila[0].ToString()),
                    int.Parse(fila[1].ToString()),
                    int.Parse(fila[2].ToString()),
                    int.Parse(fila[3].ToString()),
                    fila[4].ToString(),
                    double.Parse(fila[5].ToString()),
                    fila[6].ToString()
                );
                lista.Add(unDetalle);
            }
            return lista;
        }

        public bool Alta(DetalleDevolucion unDetalle)
        {
            string sql = "INSERT INTO DetalleDevolucion (Id, DevolucionId, EquipamientoId, Cantidad, TipoIncidencia, CargoAdicional, Observacion) "
                + "VALUES (" + unDetalle.Id + ","
                + unDetalle.DevolucionId + ","
                + unDetalle.EquipamientoId + ","
                + unDetalle.Cantidad + ",'"
                + unDetalle.TipoIncidencia + "',"
                + unDetalle.CargoAdicional + ",'"
                + unDetalle.Observacion + "')";

            return Conexion.Ejecutar(sql);
        }

        public bool Baja(int pId)
        {
            string sql = "DELETE FROM DetalleDevolucion WHERE Id = " + pId.ToString();
            return Conexion.Ejecutar(sql);
        }

        public int ProximoId()
        {
            string sql = "SELECT (ISNULL(MAX(Id),0)+1) FROM DetalleDevolucion";
            DataSet datos = Conexion.Consultar(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            int Id = int.Parse(campo[0].ToString());
            return Id;
        }
    }
}