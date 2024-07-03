using ECS.Services;
using ECS.Tags;
using LeoEcsPhysics;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Player.Baggage
{
    sealed class BaggageSystem : IEcsRunSystem 
    {
        private readonly EcsWorld _world = null;
        private EcsFilter<OnTriggerEnterEvent> _filter;
        private EcsFilter<BaggageData, PlayerTag> _baggageFilter;

        private CollisionCheckService _collisionCheckService;

        void IEcsRunSystem.Run() 
        {
            foreach (var i in _filter)
            {
                ref var eventData = ref _filter.Get1(i);
                bool playerCollided = _collisionCheckService.CheckCollisionObjects(eventData, "Player", "Item");
                if (!playerCollided) return;

                AddItem();
            }
        }

        private void AddItem()
        {

        }
    }
}