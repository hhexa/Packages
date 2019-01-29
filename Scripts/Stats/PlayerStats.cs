using UnityEngine;
using Kira.InventorySystem;

namespace Kira.Characters
{
    public class PlayerStats : MonoBehaviour
    {
        StatsHandler stats = new StatsHandler();
        [SerializeField] Transform statsPanel;
        [SerializeField] StatDisplay[] statDisplays;

        private void OnValidate()
        {
            if (statsPanel != null)
                statDisplays = statsPanel.GetComponentsInChildren<StatDisplay>();
            RefreshUI();
        }

        public Stat[] Stats
        {
            get
            {
                return stats.Stats;
            }
        }

        private void RefreshUI()
        {
            int i = 0;
            foreach (Stat stat in Stats)
            {
                statDisplays[i].SetStat(stat);
                i++;
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
                stats.OnItemEquip(eqItem);
                RefreshUI();
            }
        }

        public void OnItemUnEquip(Item item)
        {
            if (item is EquippableItem)
            {
                EquippableItem eqItem = (EquippableItem)item;
                stats.OnItemUnEquip(eqItem);
                RefreshUI();
            }
        }
    }
}