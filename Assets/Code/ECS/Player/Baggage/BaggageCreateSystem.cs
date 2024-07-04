using ECS.BaseComponents;
using ECS.Events;
using ECS.Tags;
using Leopotam.Ecs;
using SO;
using UnityEngine;

namespace ECS.Player.Baggage
{
    sealed class BaggageCreateSystem : IEcsRunSystem 
    {
        private readonly EcsWorld _world = null;
        private EcsFilter<BaggageData, TransformData, GetItemEvent, PlayerTag> _filter;
        private BaggageConfig _baggageConfig;

        private Vector3 positionItem;
        private Transform parent;
        
        void IEcsRunSystem.Run () 
        {
            foreach(var i in _filter)
            {
                ref var baggageData = ref _filter.Get1(i);
                ref var transformData = ref _filter.Get2(i);
                CreateItem(baggageData, transformData);
            }
        }

        private void CreateItem(BaggageData baggageData, TransformData transformData)
        {
            parent = transformData.transform;
            positionItem = _baggageConfig.shift;
            //positionItem.y += baggageData.items.Count * _baggageConfig.increasingNewItem;

            GameObject item = GameObject.Instantiate(_baggageConfig.prefab, positionItem, Quaternion.identity, parent);
            item.GetComponent<MeshRenderer>().material = baggageData.items.Peek().material;
        }
    }
}