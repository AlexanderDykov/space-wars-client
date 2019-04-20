using Game.ECS.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Game.ECS.Systems.Spawn
{
    public sealed class SpawnSystem: ComponentSystem
    {
        private EntityQuery _group;
        
        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            _group = GetEntityQuery(typeof(SpawnerData));
        }

        protected override void OnUpdate()
        {
            using (var spawners = _group.ToEntityArray(Allocator.TempJob))
            {
                foreach (var spawner in spawners)
                {
                    var prefab = EntityManager.GetSharedComponentData<SpawnerData>(spawner).prefab;
                    
                    var entity = Object.Instantiate(prefab).GetComponent<GameObjectEntity>().Entity;

                    EntityManager.AddComponent(entity, typeof(Translation));
                    EntityManager.AddComponent(entity, typeof(CopyTransformToGameObject));
                    EntityManager.AddComponent(entity, typeof(LocalToWorld));
                    EntityManager.AddComponent(entity, typeof(InputData));
                    EntityManager.AddComponent(entity, typeof(PlayerData));
                    
                    var position = EntityManager.GetComponentData<Translation>(spawner);
                    EntityManager.SetComponentData(entity, new Translation { Value = position.Value});
                    
                    EntityManager.DestroyEntity(spawner);
                }
            }
        }
    }
}