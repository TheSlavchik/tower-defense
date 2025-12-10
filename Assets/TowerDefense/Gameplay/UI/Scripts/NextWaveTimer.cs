using System.Collections;
using TowerDefense.Gameplay.Environment.Scripts.WaveHandler;
using TowerDefense.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Gameplay.UI.Scripts
{
    public class NextWaveTimer : MonoBehaviour, IInitializable
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _timeToShow;

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
            _slider.maxValue = _timeToShow;
            _slider.value = 0;

            StartCoroutine(ShowCoroutine(time - _timeToShow));
        }

        private IEnumerator ShowCoroutine(float timeBeforeShow)
        {
            yield return new WaitForSeconds(timeBeforeShow);
            
            _slider.gameObject.SetActive(true);
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
