
namespace AlquilerAudiovisual.Dominio
{
    public class StockEquipamiento
    {
        private int aId;
        private int aCantidadTotal;
        private int aCantidadDisponible;
        private Equipamiento aEquipamiento;
        private Deposito aDeposito;

        public int CantidadTotal { get { return aCantidadTotal; } set { aCantidadTotal = value; } }
        public int CantidadDisponible { get { return aCantidadDisponible; } set { aCantidadDisponible = value; } }
        public Equipamiento Equipamiento { get { return aEquipamiento; } set { aEquipamiento = value; } }
        public Deposito Deposito { get { return aDeposito; } set { aDeposito = value; } }

        public StockEquipamiento(int pId, int pCantidadTotal, int pCantidadDisponible, Equipamiento pEquipamiento, Deposito pDeposito)
        {
            aId = pId;
            aCantidadTotal = pCantidadTotal;
            aCantidadDisponible = pCantidadDisponible;
            aEquipamiento = pEquipamiento;
            aDeposito = pDeposito;
        }
    }
}
