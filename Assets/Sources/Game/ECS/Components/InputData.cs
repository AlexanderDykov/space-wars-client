using System;
using Unity.Entities;

namespace Game.ECS.Components
{
    [Serializable]
    public struct InputData : IComponentData
    {
        public float horizontal;
        public float vertical;
    }
}