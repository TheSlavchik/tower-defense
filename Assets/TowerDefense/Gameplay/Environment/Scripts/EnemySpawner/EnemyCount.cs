using System;
using TowerDefense.Gameplay.Enemies.Scripts;
using UnityEngine;

namespace TowerDefense.Gameplay.Environment.Scripts.EnemySpawner
{
    [Serializable]
    public struct EnemyCount
    {
        [field:SerializeField] public Enemy Enemy { get; private set; }
        [field:SerializeField] public int Count { get; private set; }
    }
}
