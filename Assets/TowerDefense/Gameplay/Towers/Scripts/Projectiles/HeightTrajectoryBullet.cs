using TowerDefense.Gameplay.Enemies.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Towers.Scripts.Projectiles
{
    public class HeightTrajectoryBullet : Bullet
    {
        [SerializeField] private float _gravity = Physics.gravity.y;
        [SerializeField] private float _explodeRadius;
        [SerializeField] private Collider _bulletCollider;
        
        private Vector3 _shootDirection;
        private float _distance;
        
        public void Shoot(float flyTime, Vector3 destinationPosition, int damage)
        {
            _damage = damage;
            _disposeCoroutine = StartCoroutine(DisposeBulletCoroutine());
            
            _rb.linearVelocity = CalculateLaunchVelocity(flyTime, destinationPosition, _transform.position);
        }

        private Vector3 CalculateLaunchVelocity(float time, Vector3 targetPosition, Vector3 initialPosition)
        {
            Vector3 displacement = targetPosition - initialPosition;

            float horizontalDistance = new Vector2(displacement.x, displacement.z).magnitude;
            float verticalDistance = displacement.y;
            float gravity = Mathf.Abs(_gravity);
            float horizontalVelocity = horizontalDistance / time;
            float verticalVelocity = (verticalDistance + 0.5f * gravity * time * time) / time;
            
            Vector3 launchVelocity;

            if (horizontalDistance > 0.001f)
            {
                launchVelocity = new Vector3(displacement.x, 0, displacement.z).normalized * horizontalVelocity;
            }
            else
            {
                launchVelocity = Vector3.forward * horizontalVelocity;
            }
            
            launchVelocity.y = verticalVelocity;

            return launchVelocity;
        }

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Enemy>())
            {
                _bulletCollider.enabled = false;
                print($"Trigger {other.gameObject.name}");
                Explode();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            _bulletCollider.enabled = false;
            print($"Collision {other.gameObject.name}");
            Explode();
        }

        private void Explode()
        {
            print("EXPLODE!");
            
            Collider[] hitColliders = Physics.OverlapSphere(_transform.position, _explodeRadius);

            foreach (var explodedObject in hitColliders)
            {
                Enemy enemy = explodedObject.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.HealthSystem.SetDamage(_damage);
                    DisposeBullet();
                    StopCoroutine(_disposeCoroutine);
                }
            }
            
            DisposeBullet();
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(transform.position, _explodeRadius);
        }

        public override void Reset()
        {
            _bulletCollider.enabled = true;
            base.Reset();
        }
    }
}
