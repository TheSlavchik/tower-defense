using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Towers.Scripts
{
    public class Rotator : MonoBehaviour, IInitializable
    {
        [SerializeField] private Transform _rotationTransform;
        [SerializeField] private EnemiesChecker _enemiesChecker;

        private Vector3 _targetPosition;
        
        public void Initialize()
        {
            _enemiesChecker.OnHaveTarget.AddListener(SetTargetPosition);
        }
        
        private void FixedUpdate()
        {
            Rotate();
        }

        private void SetTargetPosition(Transform target)
        {
            _targetPosition = target.position;
        }
        
        private void Rotate()
        {
            Vector3 lookVector = new (_targetPosition.x, _rotationTransform.position.y, _targetPosition.z);
            
            _rotationTransform.LookAt(lookVector);
        }
    }
}
