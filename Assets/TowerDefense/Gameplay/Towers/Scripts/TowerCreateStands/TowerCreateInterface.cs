using System.Collections.Generic;
using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Towers.Scripts.TowerCreateStands
{
    public class TowerCreateInterface : MonoBehaviour, IInitializable
    {
        [SerializeField] private GameObject _interface;
        [SerializeField] private Transform _buttonsParent;
        [SerializeField] private TowerButton _towerButtonPrefab;
        [SerializeField] private TowerCreateStand _createStand;

        private List<TowerButton> _towerButtons = new();
        
        public void Initialize()
        {
            foreach (Tower tower in _createStand.Towers)
            {
                TowerButton button = Instantiate(_towerButtonPrefab, _buttonsParent);
                
                button.SetTower(tower);
                button.OnTowerSelected.AddListener(_createStand.CreateTower);
                _towerButtons.Add(button);
            }
        }
        
        public void Show()
        {
            _interface.SetActive(true);
        }

        public void Hide()
        {
            _interface.SetActive(true);
        }
    }
}
