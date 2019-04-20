using Game.ECS.Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Game.ECS.Systems.Movement
{
    public class MoveSystem : JobComponentSystem
    {
        [BurstCompile]
        private struct MoveJob : IJobForEach<InputData, Translation, PlayerData, Speed>
        {
            public float Dt;

            public void Execute([ReadOnly] ref InputData input, ref Translation translation, [ReadOnly] ref PlayerData c2, [ReadOnly] ref Speed speed)
            {
                translation.Value = translation.Value + new float3(input.horizontal, input.vertical, 0) * Dt * speed.value;
            }
        }
        
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var moveJob = new MoveJob
            {
                Dt = Time.deltaTime,
            };
            return moveJob.Schedule(this, inputDeps);
        }
    }
}