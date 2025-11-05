using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TowerDefense.Gameplay.Towers.Scripts.TowerCreateStands
{
    public class TowerButton : MonoBehaviour
    {
        public UnityEvent<Tower> OnTowerSelected = new();
        
        [SerializeField] private Image _image;

        private Tower _tower;

        public void SetTower(Tower towerPrefab)
        {
            _tower = towerPrefab;
            _image.sprite = towerPrefab.Icon;
        }

        public void Select()
        {
            OnTowerSelected.Invoke(_tower);
        }
    }
}
