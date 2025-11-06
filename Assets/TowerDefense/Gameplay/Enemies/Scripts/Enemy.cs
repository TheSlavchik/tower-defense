using TowerDefense.Gameplay.Environment.Scripts.Money.Scripts;
using TowerDefense.Gameplay.Scripts.Entities;
using TowerDefense.Gameplay.Scripts.ObjectPooling;
using TowerDefense.Gameplay.UI.Scripts;
using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Enemies.Scripts
{
    public class Enemy : MonoBehaviour, IInitializable, IPoolable
    {
        [SerializeField] private int _enemyCost;
        [field: SerializeField] public HealthVisualizer HealthVisualizer { get; private set; }
        [field: SerializeField] public BillBoard BillBoard { get; private set; }
        public Movement Movement { get; private set; }
        public HealthSystem HealthSystem { get; private set; }
        public DeathHandler DeathHandler { get; private set; }

        private Bank _bank;

        public void Initialize()
        {
            Movement = GetComponent<Movement>();
            Movement.Initialize();
            HealthSystem = GetComponent<HealthSystem>();
            HealthSystem.Initialize();
            DeathHandler = GetComponent<DeathHandler>();
            DeathHandler.Initialize();
            HealthVisualizer.Initialize();
            BillBoard.Initialize();
            
            _bank = ServiceLocator.GetService<Bank>();
            DeathHandler.OnDeath.AddListener(AddMoneyForDeath);
        }

        private void AddMoneyForDeath(Enemy enemy)
        {
            _bank.AddMoney(_enemyCost);
            DeathHandler.OnDeath.RemoveListener(AddMoneyForDeath);
        }
        
        public void Reset()
        {
            HealthSystem.Initialize();
        }
    }
}
