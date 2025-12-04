using TowerDefense.Gameplay.UI.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Towers.Scripts.UI
{
    public class OpenedConditionBillboard : BillBoard
    {
        [SerializeField] private GameObject _isOpenedGameObject;

        protected override void Update()
        {
            if (_isOpenedGameObject.activeSelf)
            {
                Look();
            }
        }
    }
}
