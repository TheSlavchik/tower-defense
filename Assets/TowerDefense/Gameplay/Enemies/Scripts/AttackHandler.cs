using System;
using TowerDefense.Gameplay.Environment.Scripts.MainTower;
using TowerDefense.Gameplay.Scripts.Entities;
using UnityEngine;

namespace TowerDefense.Gameplay.Enemies.Scripts
{
    public class AttackHandler : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private HealthSystem _enemyHealthSystem;
        
        private void OnTriggerEnter(Collider other)
        {
            MainTower mainTower = other.GetComponent<MainTower>();
            
            if (mainTower != null)
            {
                mainTower.HealthSystem.SetDamage(_damage);
                _enemyHealthSystem.SetDamage(_enemyHealthSystem.MaxHealth);
            }
        }
    }
}
