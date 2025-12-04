using System.Collections;
using TowerDefense.Scripts;
using UnityEngine;
using UnityEngine.AI;

namespace TowerDefense.Gameplay.Enemies.Scripts
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Movement : MonoBehaviour, IInitializable
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _defaultSpeedMultiplier = 1;

        private NavMeshAgent _agent;
        private Transform _target;
        private Coroutine _stopMultiplierCoroutine;
        private float _speedMultiplier;
        
        public void Initialize()
        {
            _agent = GetComponent<NavMeshAgent>();
            _speedMultiplier = _defaultSpeedMultiplier;
            _agent.speed = _speed * _speedMultiplier;
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

        public void SetSpeedMultiplier(float multiplier, float time)
        {
            _speedMultiplier = multiplier;
            _agent.speed = _speed * _speedMultiplier;
            StartCoroutine(RemoveSpeedMultiplier(time));
        }
        
        private IEnumerator RemoveSpeedMultiplier(float time)
        {
            yield return new WaitForSeconds(time);
            _speedMultiplier = _defaultSpeedMultiplier;
            _agent.speed = _speed * _speedMultiplier;
        }
    }
}
