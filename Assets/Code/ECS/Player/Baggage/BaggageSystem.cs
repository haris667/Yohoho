using ECS.BaseComponents;
using ECS.Events;
using ECS.Items;
using ECS.Services;
using ECS.Tags;
using ECS.UI;
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
        private EcsFilter<ContainerData> _containerFilter;

        private CollisionCheckService _collisionCheckService;
        private EcsEventService _eventService;

        void IEcsInitSystem.Init()
        {
            foreach (var i in _baggageFilter)
            {
                ref var baggageData = ref _baggageFilter.Get1(i);
                baggageData.items = new Stack<ItemData>();
                baggageData.createdItems = new Stack<Transform>();
            }
        }

        void IEcsRunSystem.Run() 
        {
            foreach (var i in _filter)
            {
                ref var eventData = ref _filter.Get1(i);

                bool playerWithItem = _collisionCheckService.CheckCollisionObjects(eventData, "Item", "Player");
                bool playerWithContainer = _collisionCheckService.CheckCollisionObjects(eventData, "Container", "Player");

                if (playerWithItem) AddItem(eventData);
                else if (playerWithContainer) RemoveItem(eventData);
            }
        }

        private void AddItem(OnTriggerEnterEvent eventData)
        {
            EcsEntity entityWithItemData = _collisionCheckService.FindEntityWithCollision(eventData, _itemsFilter);
            ItemData item = entityWithItemData.Get<ItemData>();

            foreach(var i in _baggageFilter)
            {
                ref var baggageData = ref _baggageFilter.Get1(i);
                baggageData.items.Push(item);

                var listener = _baggageFilter.GetEntity(i);
                _eventService.Invoke<GetItemEvent>(listener);

                GameObject.Destroy(eventData.collider.gameObject);
            }
        }

        private void RemoveItem(OnTriggerEnterEvent eventData)
        {
            EcsEntity entityWithContainerData = _collisionCheckService.FindEntityWithCollision(eventData, _containerFilter);
            ContainerData container = entityWithContainerData.Get<ContainerData>();

            foreach (var i in _baggageFilter)
            {
                ref var baggageData = ref _baggageFilter.Get1(i);

                while ((baggageData.createdItems.Count > 0 &&
                    container.type == baggageData.items.Peek().type))
                {

                    container.items.Add(baggageData.items.Pop());
                    container.textAmount.text = container.items.Count.ToString();
                    GameObject.Destroy(baggageData.createdItems.Pop().gameObject);

                    _eventService.Invoke<RemoveItemEvent>(entityWithContainerData);
                }
            }
        }
    }
}