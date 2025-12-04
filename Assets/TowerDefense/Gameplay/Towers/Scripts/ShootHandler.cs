using System.Collections;
using TowerDefense.Gameplay.Scripts.ObjectPooling;
using TowerDefense.Gameplay.Towers.Scripts.Projectiles;
using TowerDefense.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense.Gameplay.Towers.Scripts
{
    public class ShootHandler : MonoBehaviour, IInitializable
    {
        public UnityEvent OnShoot = new();
        
        [SerializeField] protected int _damage;
        [SerializeField] private float _reloadDelay;
        [SerializeField] protected float _projectileSpeed;
        [SerializeField] protected Projectile _projectile;
        [SerializeField] private EnemiesChecker _enemiesChecker;
        [SerializeField] protected Transform _shootPoint;
        [SerializeField] protected Vector3 _targetPositionOffset;
        [SerializeField] protected float _shootAhead;

        protected bool _isReloading;
        protected Pool _pool;
        protected Vector3 _targetPosition;

        public void Initialize()
        {
            _enemiesChecker.OnHaveTarget.AddListener(Shoot);
            _pool = ServiceLocator.GetService<Pool>();
        }

        protected virtual void Shoot(Transform target)
        {
            if (!_isReloading)
            {
                Projectile projectile = _pool.GetFromPool(_projectile.gameObject).GetComponent<Projectile>();
                projectile.Initialize();

                Transform projectileTransform = projectile.transform;
                
                projectileTransform.rotation = _shootPoint.rotation;
                projectileTransform.position = _shootPoint.position;
                _targetPosition = target.position + _targetPositionOffset + target.forward * _shootAhead;
                projectile.Shoot(_targetPosition, _projectileSpeed, _damage);
                StartCoroutine(Reload());
                OnShoot.Invoke();
            }
        }

        protected IEnumerator Reload()
        {
            _isReloading = true;
            
            yield return new WaitForSeconds(_reloadDelay);

            _isReloading = false;
        }

        public void AddDamage(int damage)
        {
            if (damage >= 0)
            {
                _damage += damage;
            }
            else
            {
                print($"Incorrect damage {damage}");
            }
        }

        public void RemoveReloadDelay(float delay)
        {
            if (delay >= 0)
            {
                if (_reloadDelay > delay)
                {
                    _reloadDelay -= delay;
                }
                else
                {
                    print($"To big remove delay {delay}");
                }
            }
            else
            {
                print($"Incorrect delay {delay}");
            }
        }
    }
}
