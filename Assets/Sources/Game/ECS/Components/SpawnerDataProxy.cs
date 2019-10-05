using System;
using Unity.Entities;
using UnityEngine;

namespace Game.ECS.Components
{
    [Serializable]
    public struct SpawnerData : ISharedComponentData, IEquatable<SpawnerData>
    {
        public GameObject prefab;

        public bool Equals(SpawnerData other)
        {
            return Equals(prefab, other.prefab);
        }

        public override int GetHashCode()
        {
            return (prefab != null ? prefab.GetHashCode() : 0);
        }
    }
    
    public class SpawnerDataProxy : SharedComponentDataProxy<SpawnerData>
    {
        
    }
}