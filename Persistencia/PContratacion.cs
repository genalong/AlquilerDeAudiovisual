using System.Data;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Persistencia
{
    public class PContratacion
    {
        private Conexion Conexion = new Conexion();

        public List<Contratacion> ListaContrataciones()
        {
            string sql = "SELECT * FROM Contratacion";
            DataSet datos = Conexion.Consultar(sql);
            List<Contratacion> lista = new List<Contratacion>();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Contratacion unaContratacion = new Contratacion(
                    int.Parse(fila[0].ToString()),
                    int.Parse(fila[1].ToString()),
                    int.Parse(fila[2].ToString()),
                    int.Parse(fila[3].ToString()),
                    DateTime.Parse(fila[4].ToString()),
                    DateTime.Parse(fila[5].ToString()),
                    fila[6].ToString(),
                    double.Parse(fila[7].ToString()),
                    fila[8].ToString()
                );
                lista.Add(unaContratacion);
            }
            return lista;
        }

        public bool Alta(Contratacion unaContratacion)
        {
            string sql = "INSERT INTO Contratacion "
                + "(Id, ClienteId, EquipamientoId, Cantidad, FechaInicio, FechaFin, Ubicacion, ImporteTotal, Estado) "
                + "VALUES (" + unaContratacion.Id + ","
                + unaContratacion.ClienteId + ","
                + unaContratacion.EquipamientoId + ","
                + unaContratacion.Cantidad + ",'"
                + unaContratacion.FechaInicio.ToString("yyyy-MM-dd") + "','"
                + unaContratacion.FechaFin.ToString("yyyy-MM-dd") + "','"
                + unaContratacion.Ubicacion + "',"
                + unaContratacion.ImporteTotal + ",'"
                + unaContratacion.Estado + "')";

            return Conexion.Ejecutar(sql);
        }

        public bool Baja(int pId)
        {
            string sql = "DELETE FROM Contratacion WHERE Id = " + pId.ToString();
            return Conexion.Ejecutar(sql);
        }

        public bool Modificar(Contratacion unaContratacion)
        {
            string sql = "UPDATE Contratacion SET "
                + "ClienteId = " + unaContratacion.ClienteId + ","
                + "EquipamientoId = " + unaContratacion.EquipamientoId + ","
                + "Cantidad = " + unaContratacion.Cantidad + ","
                + "FechaInicio = '" + unaContratacion.FechaInicio.ToString("yyyy-MM-dd") + "',"
                + "FechaFin = '" + unaContratacion.FechaFin.ToString("yyyy-MM-dd") + "',"
                + "Ubicacion = '" + unaContratacion.Ubicacion + "',"
                + "ImporteTotal = " + unaContratacion.ImporteTotal + ","
                + "Estado = '" + unaContratacion.Estado + "' "
                + "WHERE Id = " + unaContratacion.Id.ToString();

            return Conexion.Ejecutar(sql);
        }

        public int ProximoId()
        {
            string sql = "SELECT (ISNULL(MAX(Id),0)+1) FROM Contratacion";
            DataSet datos = Conexion.Consultar(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            int Id = int.Parse(campo[0].ToString());
            return Id;
        }
    }
}