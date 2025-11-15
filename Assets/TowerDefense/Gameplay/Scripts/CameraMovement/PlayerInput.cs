using UnityEngine;

namespace TowerDefense.Gameplay.Scripts.CameraMovement
{
    public abstract class PlayerInput : MonoBehaviour
    {
        public abstract Vector3 GetCameraMoveInput();
    }
}
