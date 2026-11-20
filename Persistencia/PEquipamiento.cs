using System.Data;
using AlquilerAudiovisual.Dominio;

namespace AlquilerAudiovisual.Persistencia
{
    public class PEquipamiento
    {
        private Conexion Conexion = new Conexion();

        public List<Equipamiento> ListaEquipamientos()
        {
            string sql = "SELECT * FROM Equipamiento";
            DataSet datos = Conexion.Consultar(sql);
            List<Equipamiento> lista = new List<Equipamiento>();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Equipamiento unEquipamiento = new Equipamiento(
                    int.Parse(fila[0].ToString()),
                    fila[1].ToString(),
                    fila[2].ToString(),
                    fila[3].ToString(),
                    fila[4].ToString(),
                    int.Parse(fila[5].ToString()),
                    double.Parse(fila[6].ToString()),
                    fila[7].ToString(),
                    fila[8].ToString(),
                    fila[9].ToString(),
                    int.Parse(fila[10].ToString()),
                    bool.Parse(fila[11].ToString())
                );
                lista.Add(unEquipamiento);
            }
            return lista;
        }

        public bool Alta(Equipamiento unEquipamiento)
        {
            string sql = "INSERT INTO Equipamiento "
                + "(Id, Nombre, Marca, Modelo, Caracteristicas, DepositoId, PrecioBaseAlquiler, Codigo, Categoria, Estado, Stock, Activo) "
                + "VALUES (" + unEquipamiento.Id + ",'"
                + unEquipamiento.Nombre + "','"
                + unEquipamiento.Marca + "','"
                + unEquipamiento.Modelo + "','"
                + unEquipamiento.Caracteristicas + "',"
                + unEquipamiento.DepositoId + ","
                + unEquipamiento.PrecioBaseAlquiler + ",'"
                + unEquipamiento.Codigo + "','"
                + unEquipamiento.Categoria + "','"
                + unEquipamiento.Estado + "',"
                + unEquipamiento.Stock + ","
                + (unEquipamiento.Activo ? 1 : 0) + ")";

            return Conexion.Ejecutar(sql);
        }

        public bool Baja(int pId)
        {
            string sql = "UPDATE Equipamiento SET Activo = 0 WHERE Id = " + pId.ToString();
            return Conexion.Ejecutar(sql);
        }

        public bool Modificar(Equipamiento unEquipamiento)
        {
            string sql = "UPDATE Equipamiento SET "
                + "Nombre = '" + unEquipamiento.Nombre + "',"
                + "Marca = '" + unEquipamiento.Marca + "',"
                + "Modelo = '" + unEquipamiento.Modelo + "',"
                + "Caracteristicas = '" + unEquipamiento.Caracteristicas + "',"
                + "DepositoId = " + unEquipamiento.DepositoId + ","
                + "PrecioBaseAlquiler = " + unEquipamiento.PrecioBaseAlquiler + ","
                + "Codigo = '" + unEquipamiento.Codigo + "',"
                + "Categoria = '" + unEquipamiento.Categoria + "',"
                + "Estado = '" + unEquipamiento.Estado + "',"
                + "Stock = " + unEquipamiento.Stock + ","
                + "Activo = " + (unEquipamiento.Activo ? 1 : 0)
                + " WHERE Id = " + unEquipamiento.Id.ToString();

            return Conexion.Ejecutar(sql);
        }

        public int ProximoId()
        {
            string sql = "SELECT (ISNULL(MAX(Id),0)+1) FROM Equipamiento";
            DataSet datos = Conexion.Consultar(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            int Id = int.Parse(campo[0].ToString());
            return Id;
        }
    }
}