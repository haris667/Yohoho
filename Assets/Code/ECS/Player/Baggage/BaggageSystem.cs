using ECS.Tags;
using LeoEcsPhysics;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Player.Baggage
{
    sealed class BaggageSystem : IEcsRunSystem 
    {
        
        private readonly EcsWorld _world = null;
        private EcsFilter<OnTriggerEnterEvent, PlayerTag> _filter;
        
        void IEcsRunSystem.Run () 
        {
            foreach (var i in _filter)
            {
                ref var eventData = ref _filter.Get1(i);

                Debug.Log(eventData.collider.gameObject.name);
            }
        }
    }
}