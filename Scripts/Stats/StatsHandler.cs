using UnityEngine;
using Kira.InventorySystem;

namespace Kira.Characters
{
    [System.Serializable]
    public class StatsHandler
    {
        [SerializeField] private Stat strength = new Stat("Strength");
        [SerializeField] private Stat stamina = new Stat("Stamina");
        [SerializeField] private Stat intellect = new Stat("Intellect");

        private Stat[] stats = new Stat[3];
        private bool isDirty = true;

        public StatsHandler() { Init(); }

        public Stat[] Stats
        {
            get
            {
                if (isDirty)
                    Init();

                return stats;
            }
        }

        public void Init()
        {
            stats[0] = strength;
            stats[1] = stamina;
            stats[2] = intellect;
            isDirty = false;
        }

        public void OnItemEquip(EquippableItem eqItem)
        {
            if (eqItem.StrengthStat.amount > 0)
            {
                strength.AddMod(eqItem.StrengthStat);
            }

            if (eqItem.StaminaStat.amount > 0)
            {
                stamina.AddMod(eqItem.StaminaStat);
            }

            if (eqItem.IntellectStat.amount > 0)
            {
                intellect.AddMod(eqItem.IntellectStat);
            }
        }

        public void OnItemUnEquip(EquippableItem eqItem)
        {
            if (eqItem.StrengthStat.amount > 0)
            {
                strength.RemoveMod(eqItem.StrengthStat);
            }

            if (eqItem.StaminaStat.amount > 0)
            {
                stamina.RemoveMod(eqItem.StaminaStat);
            }

            if (eqItem.IntellectStat.amount > 0)
            {
                intellect.RemoveMod(eqItem.IntellectStat);
            }
        }
    }
}