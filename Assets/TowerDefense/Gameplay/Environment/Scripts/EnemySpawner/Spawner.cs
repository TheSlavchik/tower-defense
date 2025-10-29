using System.Collections;
using TowerDefense.Gameplay.Enemies.Scripts;
using TowerDefense.Gameplay.Scripts.ObjectPooling;
using TowerDefense.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense.Gameplay.Environment.Scripts.EnemySpawner
{
    public class Spawner : MonoBehaviour, IInitializable
    {
        public UnityEvent OnWaveSpawned = new();
        
        [SerializeField] private Transform _enemiesParent;
        
        private Path _path;
        private Pool _pool;
        
        public void Initialize()
        {
            _path = ServiceLocator.GetService<Path>();
            _pool = ServiceLocator.GetService<Pool>();
        }
        
        public IEnumerator Spawn(SpawnLayer spawnLayer)
        {
            foreach (EnemyCount enemyCount in spawnLayer.Enemies) 
            {
                for (int i = 0; i < enemyCount.Count; i++)
                {
                    Enemy enemy = _pool.GetFromPool(enemyCount.Enemy.gameObject).GetComponent<Enemy>();
                    //Instantiate(enemyCount.Enemy, _path.StartPoint.position, Quaternion.identity, _enemiesParent);
                    enemy.transform.position = _path.StartPoint.position;
                    enemy.Initialize();
                    enemy.Movement.SetTarget(_path.EndPoint);
                    enemy.Movement.StartMove();
                    
                    yield return new WaitForSeconds(spawnLayer.SpawnDelay);
                }
            }
            
            OnWaveSpawned.Invoke();
        }
    }
}
