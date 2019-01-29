using UnityEngine;

namespace Kira.Prototype
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private float damageFrequency;

        private void Update()
        {

        }

        private void DealDamageTonNearest()
        {
            // IDamagable damagable = FindObjectsOfType<IDamagable>().Order
        }
    }
}