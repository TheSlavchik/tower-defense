using TowerDefense.Gameplay.Scripts.Entities;
using TowerDefense.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense.Gameplay.Environment.Scripts.MainTower
{
    public class DestroyHandler : MonoBehaviour, IInitializable
    {
        [SerializeField] private HealthSystem _healthSystem;
        
        public UnityEvent OnMainTowerDestroyed = new();

        public void Initialize()
        {
            _healthSystem.OnHealthChanged.AddListener(HandleDestroy);
        }
        
        private void HandleDestroy(int towerHealth)
        {
            if (towerHealth == 0)
            {
                OnMainTowerDestroyed.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}
