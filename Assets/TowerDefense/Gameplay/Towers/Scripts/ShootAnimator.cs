using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Towers.Scripts
{
    public class ShootAnimator : MonoBehaviour, IInitializable
    {
        [SerializeField] private ParticleSystem _particles;
        [SerializeField] private ShootHandler _shootHandler;
        
        public void Initialize()
        {
            _shootHandler.OnShoot.AddListener(ShowParticles);
        }

        private void ShowParticles()
        {
            _particles.Play();
        }
    }
}
