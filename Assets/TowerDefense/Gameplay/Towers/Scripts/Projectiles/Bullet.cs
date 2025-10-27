using System.Collections;
using TowerDefense.Gameplay.Enemies.Scripts;
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
            gameObject.SetActive(false);
        }
    }
}
