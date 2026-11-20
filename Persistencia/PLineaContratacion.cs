using System.Data;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Persistencia
{
    public class PLineaContratacion
    {
        private Conexion Conexion = new Conexion();

        public List<LineaContratacion> ListaLineasContratacion()
        {
            string sql = "SELECT * FROM LineaContratacion";
            DataSet datos = Conexion.Consultar(sql);
            List<LineaContratacion> lista = new List<LineaContratacion>();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                LineaContratacion unaLinea = new LineaContratacion(
                    int.Parse(fila[0].ToString()),
                    int.Parse(fila[1].ToString()),
                    int.Parse(fila[2].ToString()),
                    int.Parse(fila[3].ToString()),
                    double.Parse(fila[4].ToString())
                );
                lista.Add(unaLinea);
            }
            return lista;
        }

        public bool Alta(LineaContratacion unaLinea)
        {
            string sql = "INSERT INTO LineaContratacion (Id, ContratacionId, EquipamientoId, Cantidad, PrecioUnitario) "
                + "VALUES (" + unaLinea.Id + ","
                + unaLinea.ContratacionId + ","
                + unaLinea.EquipamientoId + ","
                + unaLinea.Cantidad + ","
                + unaLinea.PrecioUnitario + ")";

            return Conexion.Ejecutar(sql);
        }

        public bool Baja(int pId)
        {
            string sql = "DELETE FROM LineaContratacion WHERE Id = " + pId.ToString();
            return Conexion.Ejecutar(sql);
        }

        public int ProximoId()
        {
            string sql = "SELECT (ISNULL(MAX(Id),0)+1) FROM LineaContratacion";
            DataSet datos = Conexion.Consultar(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            int Id = int.Parse(campo[0].ToString());
            return Id;
        }
    }
}