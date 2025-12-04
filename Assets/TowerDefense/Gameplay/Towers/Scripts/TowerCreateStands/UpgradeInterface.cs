using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Gameplay.Towers.Scripts.TowerCreateStands
{
    public class UpgradeInterface : MonoBehaviour
    {
        [SerializeField] private GameObject _interface;
        [SerializeField] private Text _costText;
        
        private UpgradeHandler _upgradeHandler;
        private bool _isEnabled;
        
        public void SetupInterface(UpgradeHandler upgradeHandler)
        {
            _upgradeHandler = upgradeHandler;
            _upgradeHandler.OnMaxUpgrade.AddListener(Disable);
            _costText.text = _upgradeHandler.CurrentCost.ToString();
        }

        public void Upgrade()
        {
            _upgradeHandler.Upgrade();
            _costText.text = _upgradeHandler.CurrentCost.ToString();
        }
        
        public void Enable()
        {
            _isEnabled = !_isEnabled;
            
            if (_interface != null)
                _interface.SetActive(_isEnabled);
        }

        public void Hide()
        {
            _isEnabled = false;
            
            if (_interface != null)
                _interface.SetActive(false);
        }

        private void Disable()
        {
            Destroy(_interface);
        }
    }
}
