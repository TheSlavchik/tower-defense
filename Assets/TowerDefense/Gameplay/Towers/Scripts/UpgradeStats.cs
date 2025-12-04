using System;
using UnityEngine;

namespace TowerDefense.Gameplay.Towers.Scripts
{
    [Serializable]
    public struct UpgradeStats
    {
        [field: SerializeField] public int UpgradeCost { get; private set; }
        [field: SerializeField] public int AddDamage { get; private set; }
        [field: SerializeField] public float RemoveReloadDelay { get; private set; }
        [field: SerializeField] public float AddDetectZone { get; private set; }
    }
}
