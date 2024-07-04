using ECS.Items;
using System.Collections.Generic;
using UnityEngine;

namespace ECS.Player.Baggage
{
    public struct BaggageData 
    {
        public Stack<ItemData> items;
        public Stack<Transform> createdItems;
    }
}