using TowerDefense.Scripts;
using UnityEngine;
using UnityEngine.AI;

namespace TowerDefense.Gameplay.Enemies.Scripts
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Movement : MonoBehaviour, IInitializable
    {
        [SerializeField] private float _speed;

        private NavMeshAgent _agent;
        private Transform _target;
        
        public void Initialize()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.speed = _speed;
        }

        public void SetTarget(Transform targetTransform)
        {
            _target = targetTransform;
        }

        public void StartMove()
        {
            _agent.SetDestination(_target.position);
            _agent.isStopped = false;
        }

        public void StopMove()
        {
            _agent.isStopped = true;
        }
    }
}
