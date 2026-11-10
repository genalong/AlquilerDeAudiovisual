namespace AlquilerAudiovisual.Dominio
{
    public class StockEquipamiento
    {
        private int aId;
        private int aCantidadTotal;
        private int aCantidadDisponible;

        public int CantidadTotal
        {
            get { return aCantidadTotal; }
            set { aCantidadTotal = value; }
        }

        public int CantidadDisponible
        {
            get { return aCantidadDisponible; }
            set { aCantidadDisponible = value; }
        }
    }
}
