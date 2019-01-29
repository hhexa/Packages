using System;
using UnityEngine;
using TMPro;

namespace Kira.Economy
{
    public class StoreInfoUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI infoText;

        private void OnValidate()
        {
            if (infoText == null)
                infoText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void ShowInfo(StoreCommodity item)
        {
            if (item == null)
                return;

            infoText.text = String.Format("Item:{0}\nStock:{1}\nPrice:{2}",
            item.commodity.DisplayName, item.stock, item.price);
            infoText.gameObject.SetActive(true);
        }

        public void HideInfo()
        {
            infoText.gameObject.SetActive(false);
        }
    }
}