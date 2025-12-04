using System;
using System.Collections;
using TowerDefense.Gameplay.Enemies.Scripts;
using TowerDefense.Gameplay.Scripts.ObjectPooling;
using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Towers.Scripts.Projectiles
{
    public class Bullet : Projectile
    {
        [SerializeField] protected Rigidbody _rb;
        [SerializeField] protected Transform _transform;
        [SerializeField] protected float _disposeTime;
        [SerializeField] protected ParticleSystem _endEffect;
        [SerializeField] protected bool _isEndParticleOnEnemy;
        [SerializeField] protected Vector3 _endEffectOffset;

        protected int _damage;
        protected Coroutine _disposeCoroutine;
        protected Pool _pool;

        public override void Initialize()
        {
            _pool = ServiceLocator.GetService<Pool>();
        }

        public override void Shoot(Vector3 destinationPosition, float speed, int damage)
        {
            _rb.AddForce((destinationPosition - _transform.position).normalized * speed);
            _damage = damage;
            _disposeCoroutine = StartCoroutine(DisposeBulletCoroutine());
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            
            if (enemy != null)
            {
                enemy.HealthSystem.SetDamage(_damage);
                
                if (_endEffect != null && _isEndParticleOnEnemy)
                {
                    Instantiate(_endEffect, enemy.transform.position + _endEffectOffset, Quaternion.identity).Play();
                }
                
                DisposeBullet();
                StopCoroutine(_disposeCoroutine);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            DisposeBullet();
            StopCoroutine(_disposeCoroutine);
        }

        protected IEnumerator DisposeBulletCoroutine()
        {
            yield return new WaitForSeconds(_disposeTime);
            
            DisposeBullet();
        }

        protected void DisposeBullet()
        {
            if (_endEffect != null && !_isEndParticleOnEnemy)
            {
                Instantiate(_endEffect, _transform.position + _endEffectOffset, Quaternion.identity).Play();
            }
            
            _pool.PutToPool(gameObject, this);
        }

        public override void Reset()
        {
            if (!_rb.isKinematic)
                _rb.linearVelocity = Vector3.zero;
        }
    }
}
