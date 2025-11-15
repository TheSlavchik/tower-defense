using UnityEngine;

namespace TowerDefense.Gameplay.Scripts.CameraMovement
{
    public class DragInput : PlayerInput
    {
        [SerializeField] private float _speedMultiplier;
        [SerializeField] private float _dragLimit;
        
        public override Vector3 GetCameraMoveInput()
        {
            if (Input.GetMouseButton(0))
            {
                return Vector3.ClampMagnitude(new Vector3(-Input.GetAxis("Mouse X"), 0, -Input.GetAxis("Mouse Y")), _dragLimit) * _speedMultiplier;
            }
            
            return Vector3.zero;
        }
    }
}
