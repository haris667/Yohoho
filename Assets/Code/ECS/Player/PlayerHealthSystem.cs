using Leopotam.Ecs;

namespace ECS.Player{
    sealed class PlayerHealthSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        
        void IEcsRunSystem.Run () {
            // add your run code here.
        }
    }
}