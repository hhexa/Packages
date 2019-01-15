using System;
using Kira.Stats;
using UnityEngine;

namespace Kira.InventorySystem
{
    public class StatsManager : MonoBehaviour
    {
        private Stat strength = new Stat("Strength");
        private Stat stamina = new Stat("Stamina");
        private Stat intellect = new Stat("Intellect");

        [SerializeField] Transform statsPanel;
        [SerializeField] StatDisplay[] statDisplays;
        Stat[] stats = new Stat[3];

        private void OnValidate()
        {
            if (statsPanel != null)
                statDisplays = statsPanel.GetComponentsInChildren<StatDisplay>();

            RefreshUI();
        }

        private void RefreshUI()
        {
            stats[0] = strength;
            stats[1] = stamina;
            stats[2] = intellect;

            for (int i = 0; i < stats.Length; i++)
            {
                statDisplays[i].SetStat(stats[i]);
            }
        }

        private void Start()
        {
            RefreshUI();
        }

        public void OnItemEquip(Item item)
        {
            if (item is EquippableItem)
            {
                EquippableItem eqItem = (EquippableItem)item;

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
                RefreshUI();
            }
        }

        public void OnItemUnEquip(Item item)
        {
            if (item is EquippableItem)
            {
                EquippableItem eqItem = (EquippableItem)item;

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
                RefreshUI();
            }
        }

    }
}