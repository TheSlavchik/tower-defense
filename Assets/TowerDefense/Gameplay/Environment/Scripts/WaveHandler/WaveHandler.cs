using TowerDefense.Gameplay.Environment.Scripts.EnemySpawner;
using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Environment.Scripts.WaveHandler
{
    public class WaveHandler : MonoBehaviour, IInitializable
    {
        [SerializeField] private SpawnLayer _test;
        
        private Spawner _spawner;
        
        public void Initialize()
        {
            _spawner = ServiceLocator.GetService<Spawner>();
            StartCoroutine(_spawner.Spawn(_test));
        }
    }
}
