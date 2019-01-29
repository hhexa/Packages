using System;
using UnityEngine;

namespace Kira.Economy
{
    [CreateAssetMenu(menuName = "Economy/Commodity", fileName = "New Commidity", order = 0)]
    public class Commodity : ScriptableObject
    {
        [SerializeField] private string displayName;
        [SerializeField] private int id;
        [SerializeField] private Sprite icon;
        [SerializeField] private float marketValue;

        public Sprite Icon { get => icon; set => icon = value; }
        public int Id { get => id; set => id = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public float MarketValue { get => marketValue; set => marketValue = value; }
        public override string ToString() => $"{DisplayName} \n{MarketValue}$";
    }
}