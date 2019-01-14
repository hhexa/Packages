using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [System.Serializable]
    public class Item
    {
        [SerializeField]
        protected string displayName;

        [SerializeField]
        protected Sprite icon;

        public Item()
        {
        }

        public Item(string displayName, Sprite icon)
        {
            this.displayName = displayName;
            this.icon = icon;
        }

        public virtual void UseItem()
        {
        }

        public string DisplayName { get { return displayName; } protected set { displayName = value; } }
        public Sprite Icon { get { return icon; } protected set { icon = value; } }
    }
}