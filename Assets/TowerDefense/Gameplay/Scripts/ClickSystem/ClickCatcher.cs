using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Scripts.ClickSystem
{
    public class ClickCatcher : MonoBehaviour, IInitializable
    {
        [SerializeField] private LayerMask _clickableLayers;
        
        private Camera _camera;
        
        public void Initialize()
        {
            _camera = ServiceLocator.GetService<Camera>();
            
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckClick();
            }
        }

        private void CheckClick()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, _clickableLayers))
            {
                IClickable clickable = hit.transform.GetComponent<IClickable>();

                clickable?.HandleClick();
            }
        }
    }
}
