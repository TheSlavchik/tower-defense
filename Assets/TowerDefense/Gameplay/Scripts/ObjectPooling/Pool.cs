using System.Collections.Generic;
using TowerDefense.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Scripts.ObjectPooling
{
    public class Pool : MonoBehaviour, IInitializable
    {
        [SerializeField] private Transform _poolObjectsParent;
        
        private Dictionary<string, LinkedList<GameObject>> _poolObjects;
        
        public void Initialize()
        {
            _poolObjects = new Dictionary<string, LinkedList<GameObject>>();
        }

        public GameObject GetFromPool(GameObject prefab)
        {
            if (!_poolObjects.ContainsKey(prefab.name))
            {
                _poolObjects.Add(prefab.name, new LinkedList<GameObject>());
            }

            GameObject result;

            if (_poolObjects[prefab.name].Count > 0)
            {
                result = _poolObjects[prefab.name].First.Value;
                _poolObjects[prefab.name].RemoveFirst();
                result.SetActive(true);
                return result;
            }

            result = Instantiate(prefab);
            result.name = prefab.name;

            return result;
        }

        public void PutToPool(GameObject target, IPoolable poolable = null)
        {
            _poolObjects[target.name].AddFirst(target);
            target.transform.SetParent(_poolObjectsParent);
            target.SetActive(false);

            if (poolable != null)
            {
                poolable.Reset();
            }
        }
    }
}
