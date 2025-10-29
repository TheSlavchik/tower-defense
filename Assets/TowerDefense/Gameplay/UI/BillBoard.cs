using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.UI
{
    public class BillBoard : MonoBehaviour, IInitializable
    {
        private Transform _transform;
        private Transform _camera;

        public void Initialize()
        {
            _transform = transform;
            _camera = ServiceLocator.GetService<Camera>().transform;
        }

        private void Update()
        {
            _transform.LookAt(_camera);
        }
    }
}
