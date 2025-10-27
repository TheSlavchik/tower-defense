using UnityEngine;

namespace TowerDefense.Gameplay.Towers.Scripts.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        public abstract void Shoot(Vector3 destinationPosition, float speed, int damage);
    }
}
