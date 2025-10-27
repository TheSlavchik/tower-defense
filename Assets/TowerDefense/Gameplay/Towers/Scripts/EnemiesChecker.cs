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

        private List<Transform> _targets = new();

        private void FixedUpdate()
        {
            if (_targets.Count > 0)
            {
                OnHaveTarget.Invoke(_targets[0]);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                _targets.Add(other.transform);
                enemy.DeathHandler.OnDeath.AddListener(RemoveDeathEnemy);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                _targets.Remove(other.transform);
                enemy.DeathHandler.OnDeath.RemoveListener(RemoveDeathEnemy);
            }
        }

        private void RemoveDeathEnemy(Enemy enemy)
        {
            _targets.Remove(enemy.transform);
            enemy.DeathHandler.OnDeath.RemoveListener(RemoveDeathEnemy);
        }
    }
}
