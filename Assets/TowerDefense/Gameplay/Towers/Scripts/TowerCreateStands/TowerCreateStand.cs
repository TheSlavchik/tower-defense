using System.Collections.Generic;
using TowerDefense.Gameplay.Scripts.ClickSystem;
using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Towers.Scripts.TowerCreateStands
{
    public class TowerCreateStand : MonoBehaviour, IInitializable, IClickable
    {
        [field:SerializeField] public List<Tower> Towers { get; private set; }
        [SerializeField] private Transform _spawnTransform;
        [SerializeField] private TowerCreateInterface _interface;

        private Tower _createdTower;
        private bool _isInterfaceOpened;
        
        public void Initialize()
        {
            _interface.Initialize();
        }

        public void CreateTower(Tower prefab)
        {
            _createdTower = Instantiate(prefab, _spawnTransform.position, Quaternion.identity);
            _createdTower.Initialize();
            _interface.Hide();
            enabled = false;
        }

        public void HandleClick()
        {
            if (_isInterfaceOpened)
            {
                _interface.Hide();
            }
            else
            {
                _interface.Show();
            }

            _isInterfaceOpened = !_isInterfaceOpened;
        }
    }
}
