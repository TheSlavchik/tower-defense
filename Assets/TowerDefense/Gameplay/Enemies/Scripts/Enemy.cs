using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Enemies.Scripts
{
    public class Enemy : MonoBehaviour, IInitializable
    {
        [field: SerializeField] public HealthVisualizer HealthVisualizer { get; private set; }
        public Movement Movement { get; private set; }
        public HealthSystem HealthSystem { get; private set; }
        public DeathHandler DeathHandler { get; private set; }

        public void Initialize()
        {
            Movement = GetComponent<Movement>();
            Movement.Initialize();
            HealthSystem = GetComponent<HealthSystem>();
            HealthSystem.Initialize();
            DeathHandler = GetComponent<DeathHandler>();
            DeathHandler.Initialize();
            HealthVisualizer.Initialize();
        }
    }
}
