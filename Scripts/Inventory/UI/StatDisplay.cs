using Kira.Characters;
using UnityEngine;
using TMPro;

namespace Kira.InventorySystem
{
    public class StatDisplay : MonoBehaviour
    {
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI statText;

        private Stat stat;

        private void OnValidate()
        {
            // TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
            // nameText = texts[0];
            // statText = texts[1];

            RefreshUI();
        }

        public void SetStat(Stat stat)
        {
            this.stat = stat;
            RefreshUI();
        }

        public void RefreshUI()
        {
            if (stat == null) return;
            nameText.text = stat.DisplayName;
            statText.text = stat.TotalValue.ToString("F1");
        }
    }
}