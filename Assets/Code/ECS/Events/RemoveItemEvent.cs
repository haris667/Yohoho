using ECS.Items;
using ECS.Player.Baggage;
using Leopotam.Ecs;

namespace ECS.Events
{
    struct RemoveItemEvent 
    {
        public ItemData itemData;
        public BaggageData baggageData;
    }
}