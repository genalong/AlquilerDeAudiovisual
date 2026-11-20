using System.Data;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Persistencia
{
    public class PSolicitud
    {
        private Conexion Conexion = new Conexion();

        public List<SolicitudAlquiler> ListaSolicitudes()
        {
            string sql = "SELECT * FROM SolicitudAlquiler";
            DataSet datos = Conexion.Consultar(sql);
            List<SolicitudAlquiler> lista = new List<SolicitudAlquiler>();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                SolicitudAlquiler unaSolicitud = new SolicitudAlquiler(
                    int.Parse(fila[0].ToString()),
                    int.Parse(fila[1].ToString()),
                    fila[2].ToString(),
                    fila[3].ToString(),
                    DateTime.Parse(fila[4].ToString()),
                    DateTime.Parse(fila[5].ToString()),
                    fila[6].ToString(),
                    int.Parse(fila[7].ToString()),
                    fila[8].ToString()
                );
                lista.Add(unaSolicitud);
            }
            return lista;
        }

        public bool Alta(SolicitudAlquiler unaSolicitud)
        {
            string sql = "INSERT INTO SolicitudAlquiler "
                + "(Id, ClienteId, TipoEvento, NombreEvento, FechaInicio, FechaFin, Ubicacion, CantidadAsistentes, Estado) "
                + "VALUES (" + unaSolicitud.Id + ","
                + unaSolicitud.ClienteId + ",'"
                + unaSolicitud.TipoEvento + "','"
                + unaSolicitud.NombreEvento + "','"
                + unaSolicitud.FechaInicio.ToString("yyyy-MM-dd") + "','"
                + unaSolicitud.FechaFin.ToString("yyyy-MM-dd") + "','"
                + unaSolicitud.Ubicacion + "',"
                + unaSolicitud.CantidadAsistentes + ",'"
                + unaSolicitud.Estado + "')";

            return Conexion.Ejecutar(sql);
        }

        public bool Baja(int pId)
        {
            string sql = "DELETE FROM SolicitudAlquiler WHERE Id = " + pId.ToString();
            return Conexion.Ejecutar(sql);
        }

        public bool Modificar(SolicitudAlquiler unaSolicitud)
        {
            string sql = "UPDATE SolicitudAlquiler SET "
                + "ClienteId = " + unaSolicitud.ClienteId + ","
                + "TipoEvento = '" + unaSolicitud.TipoEvento + "',"
                + "NombreEvento = '" + unaSolicitud.NombreEvento + "',"
                + "FechaInicio = '" + unaSolicitud.FechaInicio.ToString("yyyy-MM-dd") + "',"
                + "FechaFin = '" + unaSolicitud.FechaFin.ToString("yyyy-MM-dd") + "',"
                + "Ubicacion = '" + unaSolicitud.Ubicacion + "',"
                + "CantidadAsistentes = " + unaSolicitud.CantidadAsistentes + ","
                + "Estado = '" + unaSolicitud.Estado + "' "
                + "WHERE Id = " + unaSolicitud.Id.ToString();

            return Conexion.Ejecutar(sql);
        }

        public int ProximoId()
        {
            string sql = "SELECT (ISNULL(MAX(Id),0)+1) FROM SolicitudAlquiler";
            DataSet datos = Conexion.Consultar(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            int Id = int.Parse(campo[0].ToString());
            return Id;
        }
    }
}