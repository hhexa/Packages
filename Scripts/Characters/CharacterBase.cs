using UnityEngine;
using Kira.InventorySystem;

namespace Kira.Characters
{
    public abstract class CharacterBase : MonoBehaviour
    {
        [SerializeField] protected string displayName;
        [SerializeField] protected StatsHandler stats = new StatsHandler();

        public string Name
        {
            get { return displayName; }
            protected set { displayName = value; }
        }
        public StatsHandler Stats
        {
            get { return stats; }
            protected set { stats = value; }
        }
    }
}