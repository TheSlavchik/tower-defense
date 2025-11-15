using TowerDefense.Gameplay.Scripts.Entities;
using TowerDefense.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Gameplay.UI.Scripts
{
    public class HealthVisualizer : MonoBehaviour, IInitializable
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private CountVisualizer _text;
        [SerializeField] private bool _percentText;
        [SerializeField] private HealthSystem _healthSystem;
        
        public void Initialize()
        {
            _slider.maxValue = _healthSystem.MaxHealth;
            _slider.value = _healthSystem.MaxHealth;
            _healthSystem.OnHealthChanged.AddListener(Visualize);
        }

        private int ConvertToPercent(float currentValue, float maxValue)
        {
            return (int)(currentValue / maxValue * 100);
        }
        
        private void Visualize(int health)
        {
            _slider.value = health;

            if (_text)
            {
                if (_percentText)
                {
                    _text.VisualizeCount(ConvertToPercent(health, _healthSystem.MaxHealth));
                }
                else
                {
                    _text.VisualizeCount(health);
                }
            }
        }
    }
}
