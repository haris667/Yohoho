using Leopotam.Ecs;

namespace ECS.Enemy{
    sealed class EnemyMoveSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        
        void IEcsRunSystem.Run () {
            // add your run code here.
        }
    }
}