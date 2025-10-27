using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Scripts
{
    public class ServiceLocator : MonoBehaviour, IInitializable
    {
        [SerializeField] private List<GameObject> _services;

        private static List<GameObject> _servicesArr;
        private static Dictionary<Type, GameObject> _servicesDict = new();

        public void Initialize()
        {
            _servicesDict.Clear();
            _servicesArr = _services;
        }

        public static T GetService<T>()
        {
            if (_servicesDict.ContainsKey(typeof(T)))
            {
                return _servicesDict[typeof(T)].GetComponent<T>();
            }

            foreach (var item in _servicesArr)
            {
                if (item.TryGetComponent(out T service))
                {
                    _servicesDict.Add(typeof(T), item);
                    return service;
                }
            }

            throw new Exception($"Service locator not contains {typeof(T)}");
        }

        public static void RemoveService<T>(GameObject service)
        {
            _servicesArr.Remove(service);

            if (_servicesDict.ContainsKey(typeof(T)))
            { 
                _servicesDict.Remove(typeof(T));
            }
        }
    }
}