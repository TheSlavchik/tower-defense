using TowerDefense.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense.Gameplay.Enemies.Scripts
{
    public class DeathHandler : MonoBehaviour, IInitializable
    {
        public UnityEvent<Enemy> OnDeath = new();
        
        [SerializeField] private HealthSystem _healthSystem;

        private Enemy _enemy;
        
        public void Initialize()
        {
            _healthSystem.OnHealthChanged.AddListener(CheckDeath);
            _enemy = GetComponent<Enemy>();
        }

        private void CheckDeath(int health)
        {
            if (health == 0)
            {
                Death();
            }
        }
        
        private void Death()
        {
            gameObject.SetActive(false);
            OnDeath.Invoke(_enemy);
        }
    }
}
