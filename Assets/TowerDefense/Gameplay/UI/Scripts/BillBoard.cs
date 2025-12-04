using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.UI.Scripts
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

        protected virtual void Update()
        {
            Look();
        }

        protected void Look()
        {
            _transform.LookAt(_camera);
        }
    }
}
