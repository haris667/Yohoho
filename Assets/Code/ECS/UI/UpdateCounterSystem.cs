using ECS.Events;
using ECS.Items;
using ECS.Player.Baggage;
using Leopotam.Ecs;

namespace ECS.UI
{
    sealed class UpdateCounterSystem : IEcsRunSystem 
    {
        // auto-injected fields.
        private readonly EcsWorld _world = null;
        private EcsFilter<GetItemEvent> _getFilter;
        private EcsFilter<RemoveItemEvent> _removeFilter;
        private EcsFilter<CounterData> _counterFilter;
        private EcsFilter<BaggageData> _baggageFilter;

        private ItemData[] items;
        void IEcsRunSystem.Run () 
        {
            foreach (var i in _getFilter) UpdateText();

            foreach (var i in _removeFilter) UpdateText();
        }

        private void UpdateText()
        {
            foreach (var i in _counterFilter)
            {
                ref var counterData = ref _counterFilter.Get1(i);

                counterData.text.text = GetActiveItems(counterData.type).ToString();
            }

        }

        private int GetActiveItems(ItemType type)
        {
            int counter = 0;
            foreach (var i in _baggageFilter)
            {
                ref var baggageData = ref _baggageFilter.Get1(i);
                items = baggageData.items.ToArray();

                for(int j = 0; j < items.Length; j++)
                {
                    if (type == items[j].type)
                        counter++;
                }

            }
            return counter;
        }
    }
}