using System.Collections;
using UnityEngine;
using Kira.Stats;

namespace Kira.InventorySystem
{
    [CreateAssetMenu(menuName = "Create Eqiuppable Item", order = 1, fileName = "new Equippable Item")]
    public class EquippableItem : Item
    {
        public EquipmentType EquipmentType;
        [Space]
        public StatMod StrengthStat;
        public StatMod StaminaStat;
        public StatMod IntellectStat;
    }

    public enum EquipmentType
    {
        Helmet,
        Chest,
        Gloves,
        Boots,
        Weapon,
        Trinket
    }
}