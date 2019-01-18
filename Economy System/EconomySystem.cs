using System.Collections.Generic;
using UnityEngine;

namespace Kira.Economy
{
    public class EconomySystem : MonoBehaviour
    {
        [SerializeField] private List<Commodity> commodities = new List<Commodity>();
        public List<Commodity> Commodities { get => commodities; set => commodities = value; }

        private void OnGUI()
        {
            float spacing = 50;
            Rect rect = new Rect(80, 30, 400, 100);

            for (int i = 0; i < Commodities.Count; i++)
            {
                Commodity item = Commodities[i];
                GUI.Label(rect, item.ToString());
                rect.y += spacing;
            }
        }
    }
}