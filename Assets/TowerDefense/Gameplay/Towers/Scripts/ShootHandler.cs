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

        private bool _isReloading;
        private Pool _pool;

        public void Initialize()
        {
            _enemiesChecker.OnHaveTarget.AddListener(Shoot);
            _pool = ServiceLocator.GetService<Pool>();
        }
        
        public void Shoot(Transform target)
        {
            if (!_isReloading)
            {
                Projectile projectile = _pool.GetFromPool(_projectile.gameObject).GetComponent<Projectile>();
                projectile.Initialize();
                projectile.transform.position = _shootPoint.position;
                projectile.Shoot(target.position, _projectileSpeed, _damage);
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
