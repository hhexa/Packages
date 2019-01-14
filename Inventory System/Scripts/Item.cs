using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Credit to Kryzarel for his Inventory Tutorial on Youtube
//Link to the tutorial series: https://www.youtube.com/watch?v=bTPEMt1RG3s

namespace InventorySystem
{
    [CreateAssetMenu(menuName = "Create Item")]
    public class Item : ScriptableObject
    {
        [SerializeField]
        protected string displayName;

        [SerializeField]
        protected Sprite icon;

        public virtual void UseItem()
        {
        }

        public string DisplayName { get { return displayName; } protected set { displayName = value; } }
        public Sprite Icon { get { return icon; } protected set { icon = value; } }
    }
}