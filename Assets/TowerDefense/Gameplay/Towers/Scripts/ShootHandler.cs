using System.Collections;
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

        public void Initialize()
        {
            _enemiesChecker.OnHaveTarget.AddListener(Shoot);            
        }
        
        public void Shoot(Transform target)
        {
            if (!_isReloading)
            {
                Instantiate(_projectile, _shootPoint.position, Quaternion.identity).Shoot(target.position, _projectileSpeed, _damage);
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
