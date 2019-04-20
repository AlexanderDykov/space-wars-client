using System;
using Unity.Entities;
using UnityEngine;

namespace Game.ECS.Components
{
    [Serializable]
    public struct SpawnerData : ISharedComponentData
    {
        public GameObject prefab;
    }
    
    public class SpawnerDataProxy : SharedComponentDataProxy<SpawnerData>
    {
        
    }
}