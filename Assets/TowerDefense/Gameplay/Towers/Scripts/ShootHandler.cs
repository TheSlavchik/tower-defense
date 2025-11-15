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
        
        [SerializeField] private int _damage;
        [SerializeField] private float _reloadDelay;
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private Projectile _projectile;
        [SerializeField] private EnemiesChecker _enemiesChecker;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Vector3 _targetPositionOffset;

        private bool _isReloading;
        private Pool _pool;
        private Vector3 _targetPosition;

        public void Initialize()
        {
            _enemiesChecker.OnHaveTarget.AddListener(Shoot);
            _pool = ServiceLocator.GetService<Pool>();
        }

        private void Shoot(Transform target)
        {
            if (!_isReloading)
            {
                Projectile projectile = _pool.GetFromPool(_projectile.gameObject).GetComponent<Projectile>();
                projectile.Initialize();
                projectile.transform.position = _shootPoint.position;
                _targetPosition = target.position + _targetPositionOffset;
                projectile.Shoot(_targetPosition, _projectileSpeed, _damage);
                StartCoroutine(Reload());
            }
        }

        private IEnumerator Reload()
        {
            _isReloading = true;
            
            yield return new WaitForSeconds(_reloadDelay);

            _isReloading = false;
        }
    }
}
