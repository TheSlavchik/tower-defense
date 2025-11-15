using UnityEngine;

namespace TowerDefense.Gameplay.Scripts.CameraMovement
{
    public class ScrollInput : PlayerInput
    {
        public override Vector3 GetCameraMoveInput()
        {
            return new Vector3(Input.GetAxis("Mouse ScrollWheel") ,0,0);
        }
    }
}
