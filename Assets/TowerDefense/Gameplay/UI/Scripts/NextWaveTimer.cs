using TowerDefense.Gameplay.Environment.Scripts.WaveHandler;
using TowerDefense.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Gameplay.UI.Scripts
{
    public class NextWaveTimer : MonoBehaviour, IInitializable
    {
        [SerializeField] private Slider _slider;

        private WaveHandler _waveHandler;
        
        public void Initialize()
        {
            _waveHandler = ServiceLocator.GetService<WaveHandler>();
            
            _waveHandler.OnWaveSpawned.AddListener(Show);
            _waveHandler.OnWaveStarted.AddListener(Hide);
        }

        private void Hide(int wave)
        {
            _slider.gameObject.SetActive(false);
        }

        private void Show(float time)
        {
            _slider.gameObject.SetActive(true);
            _slider.maxValue = time;
            _slider.value = 0;
        }
        
        private void Update()
        {
            if (_slider.gameObject.activeSelf)
            {
                _slider.value += Time.deltaTime;
            }
        }
    }
}
