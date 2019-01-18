using System;
using UnityEngine;
using System.Collections.Generic;

namespace Kira.Combat
{
    public class Shooter : MonoBehaviour
    {
        public float damage;
        public float fireRate;
        float lastFire;

        private Ray ray;
        public event Action OnShootEvent;

        private IAttackable lastTarget;

        private void Update()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Input.GetKey(KeyCode.Space))
                Shoot();
        }

        private void Shoot()
        {
            if (Time.time < lastFire) return;

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.green, fireRate);
            lastFire = Time.time + fireRate;


            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (OnShootEvent != null)
                {
                    OnShootEvent();
                }

                IAttackable target = hit.transform.GetComponent<IAttackable>();


                if (target != null)
                {
                    if (lastTarget != target)
                    {
                        lastTarget = target;
                    }
                    target.TakeDamage(damage);
                }
            }
        }
    }
}