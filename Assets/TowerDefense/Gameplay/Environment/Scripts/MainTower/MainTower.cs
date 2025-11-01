using TowerDefense.Gameplay.Scripts.Entities;
using TowerDefense.Gameplay.UI.Scripts;
using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Environment.Scripts.MainTower
{
    public class MainTower : MonoBehaviour, IInitializable
    {
        [field: SerializeField] public HealthSystem HealthSystem { get; private set; }
        [field: SerializeField] public HealthVisualizer HealthVisualizer { get; private set; }
        [SerializeField] private BillBoard _billBoard;
        [SerializeField] private DestroyHandler _destroyHandler;
        
        public void Initialize()
        {
            HealthSystem.Initialize();
            HealthVisualizer.Initialize();
            _billBoard.Initialize();
            _destroyHandler.Initialize();
        }
    }
}
