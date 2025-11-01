using TowerDefense.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense.Gameplay.Scripts.Entities
{
    public class HealthSystem : MonoBehaviour, IInitializable
    {
        public UnityEvent<int> OnGetDamage = new();
        public UnityEvent<int> OnHealthChanged = new();
        
        [Min(1)][SerializeField] private int _maxHealth;

        public int MaxHealth => _maxHealth;
        
        private int _health;
        
        public void Initialize()
        {
            _health = _maxHealth;
        }
        
        public void SetDamage(int damage)
        {
            if (damage >= _health)
            {
                OnGetDamage.Invoke(damage);
                _health = 0;
            }
            else if (damage > 0)
            {
                _health -= damage;
                OnGetDamage.Invoke(damage);
            }
                
            OnHealthChanged.Invoke(_health);
        }
    }
}
