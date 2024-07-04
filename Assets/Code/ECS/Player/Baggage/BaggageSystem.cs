using ECS.BaseComponents;
using ECS.Items;
using ECS.Services;
using ECS.Tags;
using LeoEcsPhysics;
using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

namespace ECS.Player.Baggage
{
    sealed class BaggageSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private EcsFilter<OnTriggerEnterEvent> _filter;
        private EcsFilter<BaggageData, PlayerTag> _baggageFilter;
        private EcsFilter<ItemData, TransformData> _itemsFilter;

        private CollisionCheckService _collisionCheckService;

        void IEcsInitSystem.Init()
        {
            foreach (var i in _baggageFilter)
            {
                ref var baggageData = ref _baggageFilter.Get1(i);
                baggageData.items = new Stack<ItemData>();
            }
        }

        void IEcsRunSystem.Run() 
        {
            foreach (var i in _filter)
            {
                ref var eventData = ref _filter.Get1(i);
                bool playerCollided = _collisionCheckService.CheckCollisionObjects(eventData, "Item", "Player");
                if (!playerCollided) return;

                AddItem(eventData);
            }
        }

        private void AddItem(OnTriggerEnterEvent eventData)
        {

            Debug.Log("Add item");
            EcsEntity entityWithItemData = _collisionCheckService.FindEntityWithCollision(eventData, _itemsFilter);
            ItemData item = entityWithItemData.Get<ItemData>();

            foreach(var i in _baggageFilter)
            {
                ref var baggageData = ref _baggageFilter.Get1(i);
                baggageData.items.Push(item);

                Debug.Log(baggageData.items.Count);
            }
        }
    }
}