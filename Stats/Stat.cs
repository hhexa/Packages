using System.Collections.Generic;
using UnityEngine;

namespace Kira.Characters
{
    [System.Serializable]
    public class Stat
    {
        [SerializeField] private string displayName;
        [SerializeField] private float totalValue;
        [SerializeField] private float baseValue;

        private List<StatMod> statMods = new List<StatMod>();
        private bool isDirty = true;

        public void AddMod(StatMod mod)
        {
            statMods.Add(mod);
            isDirty = true;
        }

        public void RemoveMod(StatMod mod)
        {
            statMods.Remove(mod);
            isDirty = true;
        }

        public Stat(string displayName, float baseValue)
        {
            this.displayName = displayName;
            this.baseValue = baseValue;
        }

        public Stat(string displayName)
        {
            baseValue = 10f;
            this.displayName = displayName;
        }

        public string DisplayName
        {
            get
            {
                return displayName;
            }
        }
        public float TotalValue
        {
            get
            {
                if (isDirty)
                {
                    totalValue = baseValue;

                    foreach (StatMod mod in statMods)
                    {
                        if (mod.statType == StatType.Flat)
                        {
                            totalValue += mod.amount;
                        }
                        else if (mod.statType == StatType.Percent)
                        {
                            totalValue += totalValue * (mod.amount / 100);

                        }
                    }

                    isDirty = false;
                }

                return totalValue;
            }
        }
    }

    public enum StatType
    {
        Flat, Percent
    }

    [System.Serializable]
    public class StatMod
    {
        public StatType statType;
        //If type is percent keep stat between 1-100
        [Range(0, 100)]
        public float amount;

        public StatMod(float amount)
        {
            statType = StatType.Flat;
            this.amount = amount;
        }

        public StatMod(StatType statType, float amount)
        {
            this.statType = statType;
            this.amount = amount;
        }
    }
}