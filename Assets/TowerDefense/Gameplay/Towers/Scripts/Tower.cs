using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Towers.Scripts
{
    public class Tower : MonoBehaviour, IInitializable
    {
        [field: SerializeField] public int BuildCost { get; private set; }
        [field: SerializeField] public ShootHandler ShootHandler { get; private set; }
        [field: SerializeField] public EnemiesChecker EnemiesChecker { get; private set; }
        [field: SerializeField] public Rotator Rotator { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public UpgradeHandler UpgradeHandler { get; private set; }
        [field: SerializeField] public ShootAnimator ShootAnimator { get; private set; }
        
        public void Initialize()
        {
            ShootHandler.Initialize();
            Rotator.Initialize();
            UpgradeHandler.Initialize();

            if (ShootAnimator != null)
            {
                ShootAnimator.Initialize();
            }
        }
    }
}
