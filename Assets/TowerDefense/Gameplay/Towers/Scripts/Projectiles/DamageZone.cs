using TowerDefense.Gameplay.Enemies.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Towers.Scripts.Projectiles
{
    public class DamageZone : Bullet
    {
        [Range(0,1)][SerializeField] private float _slownessEffectMultiplier;
        [SerializeField] private float _slownessEffectTime;
        
        public override void Shoot(Vector3 destinationPosition, float speed, int damage)
        {
            _damage = damage;
            _disposeCoroutine = StartCoroutine(DisposeBulletCoroutine());
        }
        
        protected override void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            
            if (enemy != null)
            {
                enemy.HealthSystem.SetDamage(_damage);
                enemy.Movement.SetSpeedMultiplier(_slownessEffectMultiplier, _slownessEffectTime);
                
                if (_endEffect != null)
                {
                    Instantiate(_endEffect, enemy.transform.position + _endEffectOffset, Quaternion.identity).Play();
                }
            }
        }
    }
}
