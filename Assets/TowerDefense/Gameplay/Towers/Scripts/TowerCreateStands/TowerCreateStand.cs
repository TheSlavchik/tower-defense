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
        [SerializeField] private TowerCreateInterface _createInterface;
        [SerializeField] private UpgradeInterface _upgradeInterface;

        private Tower _createdTower;
        private UpgradeHandler _upgradeHandler;
        private bool _isInterfaceOpened;
        private bool _isTowerCreated;
        
        public void Initialize()
        {
            _createInterface.Initialize();
            ClickCatcher.OnEmptyClick.AddListener(Hide);
        }

        public void CreateTower(Tower prefab)
        {
            _createdTower = Instantiate(prefab, _spawnTransform.position, Quaternion.identity);
            _createdTower.Initialize();
            _createInterface.Hide();
            _isTowerCreated = true;
            _upgradeInterface.SetupInterface(_createdTower.UpgradeHandler);
        }

        public void HandleClick()
        {
            if (_isTowerCreated)
            {
                _upgradeInterface.Enable();
            }
            else
            {
                if (_isInterfaceOpened)
                {
                    _createInterface.Hide();
                }
                else
                {
                    _createInterface.Show();
                }

                _isInterfaceOpened = !_isInterfaceOpened;
            }
        }

        private void Hide()
        {
            _upgradeInterface.Hide();
            _createInterface.Hide();
        }
    }
}
