using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Scripts
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private bool _initializeOnAwake;
        [SerializeReference] private List<GameObject> _initializableObjects;

        private void Awake()
        {
            if (_initializeOnAwake)
            {
                Initialize();
            }
        }
        
        public void Initialize()
        {
            foreach (GameObject obj in _initializableObjects)
            {
                if (obj.TryGetComponent(out IInitializable initializable))
                {
                    initializable.Initialize();
                }
                else
                {
                    Debug.Log(obj.name + " is not initializable");
                }
            }
        }
    }
}