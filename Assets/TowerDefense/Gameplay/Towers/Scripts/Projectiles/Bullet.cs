using System.Collections;
using TowerDefense.Gameplay.Enemies.Scripts;
using TowerDefense.Gameplay.Scripts.ObjectPooling;
using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Towers.Scripts.Projectiles
{
    public class Bullet : Projectile
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private Transform _transform;
        [SerializeField] private float _disposeTime;

        private int _damage;
        private Coroutine _disposeCoroutine;
        private Pool _pool;

        public override void Initialize()
        {
            _pool = ServiceLocator.GetService<Pool>();
        }

        public override void Shoot(Vector3 destinationPosition, float speed, int damage)
        {
            _rb.AddForce((destinationPosition - _transform.position) * speed);
            _damage = damage;
            _disposeCoroutine = StartCoroutine(DisposeBulletCoroutine());
        }

        private void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            
            if (enemy != null)
            {
                enemy.HealthSystem.SetDamage(_damage);
                DisposeBullet();
                StopCoroutine(_disposeCoroutine);
            }
        }

        private IEnumerator DisposeBulletCoroutine()
        {
            yield return new WaitForSeconds(_disposeTime);
            
            DisposeBullet();
        }

        private void DisposeBullet()
        {
            _pool.PutToPool(gameObject, this);
        }

        public override void Reset()
        {
            _rb.linearVelocity = Vector3.zero;
        }
    }
}
