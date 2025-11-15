using TowerDefense.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense.Gameplay.Environment.Scripts.Money.Scripts
{
    public class Bank : MonoBehaviour, IInitializable
    {
        public UnityEvent<int> OnMoneyChanged = new();
        
        [SerializeField] private int _startMoney;

        private int _money;

        public void Initialize()
        {
            AddMoney(_startMoney);
        }

        public void AddMoney(int money)
        {
            if (money >= 0)
            {
                _money += money;
            }
            
            OnMoneyChanged.Invoke(_money);
        }

        public bool GetMoney(int money)
        {
            if (money <= 0)
            {
                print($"You try to get {money} coins?");
                return false;
            }

            if (money > _money)
            {
                return false;
            }

            _money -= money;
            
            OnMoneyChanged.Invoke(_money);
            
            return true;
        }
    }
}
