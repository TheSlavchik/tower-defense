using TowerDefense.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense.Gameplay.Scripts.ClickSystem
{
    public class ClickCatcher : MonoBehaviour, IInitializable
    {
        public static UnityEvent OnEmptyClick = new();
        
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

                if (clickable == null)
                {
                    OnEmptyClick.Invoke();
                }
            }
            else
            {
                OnEmptyClick.Invoke();
            }
        }
    }
}
