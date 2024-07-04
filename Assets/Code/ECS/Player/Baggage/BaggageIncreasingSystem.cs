using ECS.BaseComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Player.Baggage{
    sealed class BaggageIncreasingSystem : IEcsRunSystem 
    {
        private readonly EcsWorld _world = null;
        private EcsFilter<BaggageData, TransformData, InputData> _filter;

        private Transform[] createdItems;
        private Vector3 initialPosition;
        private Vector3 direction;
        
        void IEcsRunSystem.Run () 
        {
            foreach(var i in _filter)
            {
                ref var baggageData = ref _filter.Get1(i);
                ref var transformData = ref _filter.Get2(i);
                ref var inputData = ref _filter.Get3(i);
                createdItems = baggageData.createdItems.ToArray();

                ShiftBaggage(createdItems, inputData.joystick.Direction, transformData.transform);
            }
        }
        private void ShiftBaggage(Transform[] items, Vector2 joystickDirection, Transform parent)
        {
            Vector3 shiftDirection = new Vector3(-joystickDirection.x, 0, -joystickDirection.y);


            foreach (var item in items)
            {
                //item.localPosition = Vector3.Lerp(item.localPosition, item.localPosition + shiftDirection, 1);
                Vector3 newPosition = item.localPosition + shiftDirection;
                float distance = Vector3.Distance(newPosition, item.localPosition);

                item.localPosition += shiftDirection.normalized * Time.deltaTime;
                
            }
        }
    }
}