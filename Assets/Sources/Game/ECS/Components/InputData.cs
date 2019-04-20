using System;
using Unity.Entities;
using UnityEngine.Serialization;

namespace Game.ECS.Components
{
    [Serializable]
    public struct InputData : IComponentData
    {
        public float horizontal;
        public float vertical;
    }
}