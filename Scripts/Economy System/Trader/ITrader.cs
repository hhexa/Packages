using UnityEngine;
using System.Collections.Generic;

namespace Kira.Economy
{
    public interface ITrader
    {
        float Cash { get; }
        List<Commodity> GetCommodities();
    }
}