using System;
using Unity.Entities;

namespace Game.ECS.Components
{
    [Serializable]
    public struct Speed : IComponentData
    {
        public float value;
    }
}