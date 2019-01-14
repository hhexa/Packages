using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class ItemSlot : MonoBehaviour
    {
        private Item _item;

        public Item Item
        {
            get { return _item; }
            set
            {
                if (_item == null)
                {
                    image.enabled = false;
                }
                else
                {
                    image.sprite = _item.Icon;
                    image.enabled = true;
                }
            }
        }

        [SerializeField]
        private Image image;

        private int slotID = 0;
        public static int idCounter = 0;

        private void OnValidate()
        {
            if (image == null)
            {
                image = GetComponent<Image>();
            }
        }

        private void Awake()
        {
            idCounter++;
            slotID = idCounter;
        }
    }
}