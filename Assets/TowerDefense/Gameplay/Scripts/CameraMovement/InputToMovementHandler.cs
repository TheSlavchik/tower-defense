using UnityEngine;

namespace TowerDefense.Gameplay.Scripts.CameraMovement
{
    public class InputToMovementHandler : MonoBehaviour
    {
        [SerializeField] private KeyboardInput _keyboardInput;
        [SerializeField] private DragInput _dragInput;
        [SerializeField] private ScrollInput _scrollInput;

        public Vector3 GetMovementInput()
        {
            Vector3 input = _keyboardInput.GetCameraMoveInput();

            if (input == Vector3.zero)
            {
                input = _dragInput.GetCameraMoveInput();
            }
            
            return input;
        }

        public float GetZoomInput()
        {
            return _scrollInput.GetCameraMoveInput().x;
        }
    }
}
