using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Kira.Economy
{
    public class Trader : SerializedMonoBehaviour, ITrader
    {
        //Cash will later be in a portfolio class
        [SerializeField]
        protected float cash;

        //The commodities this Trader has
        //Later this will be in a Portfolio Class

        [SerializeField]
        protected List<Commodity> commodities;

        public float Cash
        {
            get { return cash; }
            protected set { cash = value; }
        }

        public List<Commodity> GetCommodities()
        {
            return commodities;
        }
    }
}