using ECS.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Collision
{
    //не уверен как наиболее корректно обрабатывать юнитековские ивенты в ецс, поэтому получился такой мостик
    public class CollisionHandler : MonoBehaviour
    {
        private int _entity;
        private EcsWorld _world;

        public CollisionHandler(int entity, EcsWorld world)
        {
            _entity = entity;
            _world = world;
        }

        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            var entity = _world.NewEntity();
            var collEvt = _world.GetPool<CollisionEvent>();
            ref var evt = ref collEvt.
        }
    }
}
