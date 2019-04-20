using Game.ECS.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Game.ECS.Systems
{
    public sealed class DesktopInputSystem : JobComponentSystem
    {
        [BurstCompile]
        private struct InputJob : IJobForEach<InputData>
        {
            public float Vertical;
            public float Horizontal;
            
            public void Execute(ref InputData inputData)
            {
                inputData.vertical = Vertical;
                inputData.horizontal = Horizontal;
            }
        }
        
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var iJob = new InputJob()
            {
                Vertical = Input.GetAxis("Vertical"),
                Horizontal = Input.GetAxis("Horizontal")
            };
            return iJob.Schedule(this, inputDeps);
        }
    }
}