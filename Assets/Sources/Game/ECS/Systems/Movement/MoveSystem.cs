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
        private struct MoveJob : IJobForEach<InputData, Translation, PlayerData>
        {
            public float dt;
            public float speed;

            public void Execute([ReadOnly] ref InputData input, ref Translation translation, [ReadOnly] ref PlayerData c2)
            {
                translation.Value = translation.Value + new float3(input.horizontal, input.vertical, 0) * dt * speed;
            }
        }
        
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var moveJob = new MoveJob
            {
                dt = Time.deltaTime,
                speed = 3
            };
            return moveJob.Schedule(this, inputDeps);
        }
    }
}