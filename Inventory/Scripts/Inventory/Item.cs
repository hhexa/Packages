using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Credit to Kryzarel for his Inventory Tutorial on Youtube
//Link to the tutorial series: https://www.youtube.com/watch?v=bTPEMt1RG3s

namespace Kira.InventorySystem
{
    [CreateAssetMenu(menuName = "Create Item", fileName = "new Item", order = 0)]
    public class Item : ScriptableObject, IItem
    {
        [SerializeField]
        protected string displayName;

        [SerializeField]
        protected int id;

        [SerializeField]
        protected Sprite icon;

        public virtual void UseItem()
        {
        }

        public string DisplayName { get { return displayName; } protected set { displayName = value; } }
        public int ID { get { return id; } }
        public Sprite Icon { get { return icon; } protected set { icon = value; } }
    }
}