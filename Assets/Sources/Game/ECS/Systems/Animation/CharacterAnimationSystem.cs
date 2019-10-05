using Game.ECS.Components;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Game.ECS.Systems.Animation
{
    public class CharacterAnimationSystem : ComponentSystem
    {
        private EntityQuery _group;
        private readonly int _horizontal = Animator.StringToHash("Horizontal");
        private readonly int _vertical = Animator.StringToHash("Vertical");
        
        protected override void OnCreate()
        {
            base.OnCreate();
            _group = GetEntityQuery(typeof(Animator), ComponentType.ReadWrite<InputData>(), ComponentType.ReadWrite<PlayerData>());
        }
        
        protected override void OnUpdate()
        {
            var input = _group.ToComponentDataArray<InputData>(Allocator.TempJob);
            var animators = _group.ToComponentArray<Animator>();

            for (int i = 0; i < animators.Length; i++)
            {
                animators[i].SetFloat(_horizontal, input[i].horizontal);
                animators[i].SetFloat(_vertical, input[i].vertical);
            }
            input.Dispose();
        }
    }
}