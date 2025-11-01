using TowerDefense.Gameplay.Scripts.Entities;
using TowerDefense.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Gameplay.UI.Scripts
{
    public class HealthVisualizer : MonoBehaviour, IInitializable
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private HealthSystem _healthSystem;
        
        public void Initialize()
        {
            _slider.maxValue = _healthSystem.MaxHealth;
            _slider.value = _healthSystem.MaxHealth;
            _healthSystem.OnHealthChanged.AddListener(Visualize);
        }
        
        private void Visualize(int health)
        {
            _slider.value = health;
        }
    }
}
