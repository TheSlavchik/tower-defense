using TowerDefense.Gameplay.Scripts.ObjectPooling;
using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Towers.Scripts.Projectiles
{
    public abstract class Projectile : MonoBehaviour, IInitializable, IPoolable
    {
        public abstract void Shoot(Vector3 destinationPosition, float speed, int damage);
        
        public virtual void Reset()
        {
            
        }

        public virtual void Initialize()
        {
            
        }
    }
}
