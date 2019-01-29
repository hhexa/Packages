namespace Kira.Economy
{
    [System.Serializable]
    public class StoreCommodity
    {
        public Commodity commodity;
        public float price;
        public int stock;

        public bool Purchase()
        {
            if (stock >= 1)
            {
                stock--;
                return true;
            }
            return false;
        }

        public bool Purchase(int amount)
        {
            if (stock >= amount)
            {
                stock -= amount;
                return true;
            }
            return false;
        }
    }
}