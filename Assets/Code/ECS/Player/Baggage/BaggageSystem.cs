using Leopotam.Ecs;

namespace ECS.Player.Baggage{
    sealed class BaggageSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        
        void IEcsRunSystem.Run () {
            // add your run code here.
        }
    }
}