using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Towers.Scripts
{
    public class Tower : MonoBehaviour, IInitializable
    {
        [field: SerializeField] public ShootHandler ShootHandler { get; private set; }
        [field: SerializeField] public EnemiesChecker EnemiesChecker { get; private set; }
        
        public void Initialize()
        {
            ShootHandler.Initialize();
        }
    }
}
