using System.Collections;
using TowerDefense.Gameplay.Enemies.Scripts;
using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Environment.Scripts.EnemySpawner
{
    public class Spawner : MonoBehaviour, IInitializable
    {
        [SerializeField] private Transform _enemiesParent;
        
        private Path _path;
        
        public void Initialize()
        {
            _path = ServiceLocator.GetService<Path>();
        }
        
        public IEnumerator Spawn(SpawnLayer spawnLayer)
        {
            foreach (EnemyCount enemyCount in spawnLayer.Enemies) 
            {
                for (int i = 0; i < enemyCount.Count; i++)
                {
                    Enemy enemy = Instantiate(enemyCount.Enemy, _path.StartPoint.position, Quaternion.identity, _enemiesParent);
                    enemy.Initialize();
                    enemy.Movement.SetTarget(_path.EndPoint);
                    enemy.Movement.StartMove();
                    
                    yield return new WaitForSeconds(spawnLayer.SpawnDelay);
                }
            }
        }
    }
}
