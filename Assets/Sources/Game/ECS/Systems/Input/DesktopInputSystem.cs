using Game.ECS.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;

namespace Game.ECS.Systems.Input
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
                Vertical = UnityEngine.Input.GetAxis("Vertical"),
                Horizontal = UnityEngine.Input.GetAxis("Horizontal")
            };
            return iJob.Schedule(this, inputDeps);
        }
    }
}