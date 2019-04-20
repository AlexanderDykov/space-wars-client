using System.ComponentModel;
using Game.ECS.Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Game.ECS.Systems.Animation
{
    public class CharacterAnimationSystem : ComponentSystem
    {
        private EntityQuery _group;
        
        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            _group = GetEntityQuery(typeof(Animator), ComponentType.ReadWrite<InputData>(), ComponentType.ReadWrite<PlayerData>());
        }
        
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        protected override void OnUpdate()
        {
            var input = _group.ToComponentDataArray<InputData>(Allocator.TempJob);
            var animators = _group.ToComponentArray<Animator>();

            for (int i = 0; i < animators.Length; i++)
            {
                animators[i].SetBool(IsMoving, math.abs(input[i].horizontal) > 0.1f || math.abs(input[i].vertical) > 0.1f);
                animators[i].SetFloat(Horizontal, input[i].horizontal);
                animators[i].SetFloat(Vertical, input[i].vertical);
            }
            input.Dispose();
        }
    }
}