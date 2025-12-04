using System;
using System.Collections.Generic;
using TowerDefense.Gameplay.Enemies.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense.Gameplay.Towers.Scripts
{
    [RequireComponent(typeof(SphereCollider))]
    public class EnemiesChecker : MonoBehaviour
    {
        public UnityEvent<Transform> OnHaveTarget = new();

        [SerializeField] private SphereCollider _collider;
        
        private List<Transform> _targets = new();

        private void FixedUpdate()
        {
            if (_targets.Count > 0)
            {
                if (_targets[0].gameObject.activeSelf)
                {
                    OnHaveTarget.Invoke(_targets[0]);
                }
                else
                {
                    _targets.RemoveAt(0);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                _targets.Add(other.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                _targets.Remove(other.transform);
            }
        }

        private void RemoveDeathEnemy(Enemy enemy)
        {
            _targets.Remove(enemy.transform);
            enemy.DeathHandler.OnDeath.RemoveListener(RemoveDeathEnemy);
        }

        public void AddRadius(float addRadius)
        {
            if (addRadius < 0)
            {
                print($"Incorrect radius {addRadius}");
                return;
            }

            _collider.radius += addRadius;
        }
    }
}
