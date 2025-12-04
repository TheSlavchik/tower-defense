using System.Collections.Generic;
using TowerDefense.Gameplay.Environment.Scripts.Money.Scripts;
using TowerDefense.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense.Gameplay.Towers.Scripts
{
    public class UpgradeHandler : MonoBehaviour, IInitializable
    {
        public UnityEvent OnMaxUpgrade = new();

        //public int CurrentLevel => _currentLevel;
        public int CurrentCost => _upgrades[_currentLevel].UpgradeCost;
        
        [SerializeField] private List<UpgradeStats> _upgrades;
        [SerializeField] private ShootHandler _shootHandler;
        [SerializeField] private EnemiesChecker _enemiesChecker;

        private int _currentLevel;
        private Bank _bank;

        public void Initialize()
        {
            _bank = ServiceLocator.GetService<Bank>();
        }
        
        public void Upgrade()
        {
            if (_currentLevel < _upgrades.Count)
            {
                if (_bank.GetMoney(_upgrades[_currentLevel].UpgradeCost))
                {
                    _shootHandler.AddDamage(_upgrades[_currentLevel].AddDamage);
                    _shootHandler.RemoveReloadDelay(_upgrades[_currentLevel].RemoveReloadDelay);
                    _enemiesChecker.AddRadius(_upgrades[_currentLevel].AddDetectZone);

                    if (_currentLevel + 1 >= _upgrades.Count)
                    {
                        OnMaxUpgrade.Invoke();
                    }
                    else
                    {
                        _currentLevel++;
                    }
                }
            }

        }
    }
}
