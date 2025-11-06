using System.Collections;
using System.Collections.Generic;
using TowerDefense.Gameplay.Environment.Scripts.EnemySpawner;
using TowerDefense.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense.Gameplay.Environment.Scripts.WaveHandler
{
    public class WaveHandler : MonoBehaviour, IInitializable
    {
        public UnityEvent<int> OnWaveStarted = new();
        public UnityEvent<float> OnWaveSpawned = new();
        
        [SerializeField] private List<SpawnLayer> _spawnLayers;
        
        private Spawner _spawner;
        private int _currentWave;
        private Coroutine _waitCoroutine;
        
        public void Initialize()
        {
            _spawner = ServiceLocator.GetService<Spawner>();
            _currentWave = 0;
            _spawner.OnWaveSpawned.AddListener(StartWait);
        }

        public void StartWave()
        {
            OnWaveStarted.Invoke(_currentWave);
            
            if (_waitCoroutine != null)
            {
                StopCoroutine(_waitCoroutine);    
            }
            
            StartCoroutine(_spawner.Spawn(_spawnLayers[_currentWave]));
            _currentWave += 1;
        }

        private void StartWait()
        {
            _waitCoroutine = StartCoroutine(WaitBeforeNewWave());
        }
        
        private IEnumerator WaitBeforeNewWave()
        {
            if (_currentWave < _spawnLayers.Count)
            {
                OnWaveSpawned.Invoke(_spawnLayers[_currentWave].DelayBeforeWave);
                yield return new WaitForSeconds(_spawnLayers[_currentWave].DelayBeforeWave);
                StartWave();
            }
        }
    }
}
