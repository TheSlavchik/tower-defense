using UnityEngine;

namespace TowerDefense.Gameplay.Scripts.CameraMovement
{
    public class KeyboardInput : PlayerInput
    {
        public override Vector3 GetCameraMoveInput()
        {
            /*float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            
            return Vector3.ClampMagnitude(new Vector3(horizontal, 0, vertical), 1.0f);*/

            return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        }
    }
}
