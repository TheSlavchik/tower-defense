using TowerDefense.Gameplay.Environment.Scripts.Money.Scripts;
using TowerDefense.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TowerDefense.Gameplay.Towers.Scripts.TowerCreateStands
{
    public class TowerButton : MonoBehaviour
    {
        public UnityEvent<Tower> OnTowerSelected = new();
        
        [SerializeField] private Image _image;
        [SerializeField] private Text _costText;

        private Tower _tower;
        private Bank _bank;

        public void SetTower(Tower towerPrefab)
        {
            _tower = towerPrefab;
            _image.sprite = towerPrefab.Icon;
            _costText.text = towerPrefab.BuildCost.ToString();
            _bank = ServiceLocator.GetService<Bank>();
        }

        public void Select()
        {
            if (_bank.GetMoney(_tower.BuildCost))
            {
                OnTowerSelected.Invoke(_tower);
            }
            else
            {
                print("Not enough money");
            }
        }
    }
}
