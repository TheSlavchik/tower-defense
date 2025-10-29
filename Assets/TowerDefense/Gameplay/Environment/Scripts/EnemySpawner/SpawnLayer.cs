using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Gameplay.Environment.Scripts.EnemySpawner
{
    [Serializable]
    public struct SpawnLayer
    {
        [field: SerializeField] public List<EnemyCount> Enemies { get; private set; }
        [field: SerializeField] public float SpawnDelay { get; private set; }
        [field: SerializeField] public float DelayAfterWave { get; private set; }
    }
}
