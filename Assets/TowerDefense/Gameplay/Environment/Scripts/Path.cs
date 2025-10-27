using UnityEngine;

namespace TowerDefense.Gameplay.Environment.Scripts
{
    public class Path : MonoBehaviour
    {
        [field: SerializeField] public Transform StartPoint { get; private set; }
        [field: SerializeField] public Transform EndPoint { get; private set; }
    }
}
