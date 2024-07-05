using ECS.Items;
using System.Collections.Generic;
using TMPro;
using Voody.UniLeo;

namespace ECS.Items
{
    [System.Serializable]
    public struct ContainerData
    {
        public List<ItemData> items;
        public TextMeshPro textAmount;
        public ItemType type;
    }
}