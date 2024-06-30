using Leopotam.Ecs;

namespace ECS.Player{
    sealed class InputSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        
        void IEcsRunSystem.Run () {
            // add your run code here.
        }
    }
}