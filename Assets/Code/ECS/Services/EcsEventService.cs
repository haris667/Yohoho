using ECS.Events;
using Leopotam.Ecs;

namespace ECS.Services
{
    public class EcsEventService
    {
        private EcsWorld _world;

        public EcsEventService(EcsWorld world) => _world = world;

        public void Invoke<T>() where T : struct
        {
            EcsEntity ent = _world.NewEntity();
            ent.Get<T>();
        }

        public void Invoke<T>(EcsEntity listener) where T : struct => listener.Get<T>();
    }
}
