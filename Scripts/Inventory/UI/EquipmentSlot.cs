using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kira.InventorySystem
{
    public class EquipmentSlot : ItemSlot
    {
        public EquipmentType equipmentType;

        protected override void OnValidate()
        {
            if (refreshOnValidate)
            {
                base.OnValidate();
                gameObject.name = equipmentType.ToString() + " Slot";
            }
        }
    }
}