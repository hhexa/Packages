using UnityEngine;

namespace Kira.InventorySystem
{
    public interface IItem
    {
        string DisplayName { get; }
        Sprite Icon { get; }
        int ID { get; }
    }
}