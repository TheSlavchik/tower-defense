using TowerDefense.Gameplay.Towers.Scripts.Projectiles;
using UnityEngine;

namespace TowerDefense.Gameplay.Towers.Scripts
{
    public class MortarShootHandler : ShootHandler
    {
        [SerializeField] protected float _projectileFlyTime;
        
        protected override void Shoot(Transform target)
        {
            if (_projectile is HeightTrajectoryBullet)
            {
                if (!_isReloading)
                {
                    Projectile projectile = _pool.GetFromPool(_projectile.gameObject).GetComponent<Projectile>();
                    projectile.Initialize();

                    Transform projectileTransform = projectile.transform;

                    projectileTransform.rotation = _shootPoint.rotation;
                    projectileTransform.position = _shootPoint.position;
                    _targetPosition = target.position + _targetPositionOffset + target.forward * _shootAhead;
                    ((HeightTrajectoryBullet)projectile).Shoot(_projectileFlyTime, _targetPosition, _damage);
                    StartCoroutine(Reload());
                    OnShoot.Invoke();
                }
            }
            else
            {
                base.Shoot(target);
            }
        }
    }
}
