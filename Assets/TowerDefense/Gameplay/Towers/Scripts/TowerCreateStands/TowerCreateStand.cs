using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Towers.Scripts.TowerCreateStands
{
    public class TowerCreateStand : MonoBehaviour, IInitializable
    {
        [SerializeField] private Transform _spawnTransform;

        private Tower _createdTower;
        
        public void Initialize()
        {
            
        }

        public void CreateTower(Tower prefab)
        {
            _createdTower = Instantiate(prefab, _spawnTransform.position, Quaternion.identity);
        }
    }
}
