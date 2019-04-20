using Game.ECS.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Game.ECS.Systems.Spawn
{
    public sealed class SpawnSystem : ComponentSystem
    {
        private EntityQuery _group;
        //TODO: load from some config
        public float Speed = 1.5f;
        
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
                    EntityManager.AddComponent(entity, typeof(Speed));
                    
                    var position = EntityManager.GetComponentData<Translation>(spawner);
                    EntityManager.SetComponentData(entity, new Translation { Value = position.Value });
                    EntityManager.SetComponentData(entity, new Speed { value = Speed });
                    
                    EntityManager.DestroyEntity(spawner);
                }
            }
        }
    }
}