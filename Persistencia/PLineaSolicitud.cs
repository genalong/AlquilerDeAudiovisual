using System.Data;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Persistencia
{
    public class PLineaSolicitud
    {
        private Conexion Conexion = new Conexion();

        public List<LineaSolicitud> ListaLineasSolicitud()
        {
            string sql = "SELECT * FROM LineaSolicitud";
            DataSet datos = Conexion.Consultar(sql);
            List<LineaSolicitud> lista = new List<LineaSolicitud>();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                LineaSolicitud unaLinea = new LineaSolicitud(
                    int.Parse(fila[0].ToString()),
                    int.Parse(fila[1].ToString()),
                    int.Parse(fila[2].ToString()),
                    int.Parse(fila[3].ToString())
                );
                lista.Add(unaLinea);
            }
            return lista;
        }

        public bool Alta(LineaSolicitud unaLinea)
        {
            string sql = "INSERT INTO LineaSolicitud (Id, SolicitudId, EquipamientoId, Cantidad) "
                + "VALUES (" + unaLinea.Id + ","
                + unaLinea.SolicitudId + ","
                + unaLinea.EquipamientoId + ","
                + unaLinea.Cantidad + ")";

            return Conexion.Ejecutar(sql);
        }

        public bool Baja(int pId)
        {
            string sql = "DELETE FROM LineaSolicitud WHERE Id = " + pId.ToString();
            return Conexion.Ejecutar(sql);
        }

        public int ProximoId()
        {
            string sql = "SELECT (ISNULL(MAX(Id),0)+1) FROM LineaSolicitud";
            DataSet datos = Conexion.Consultar(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            int Id = int.Parse(campo[0].ToString());
            return Id;
        }
    }
}