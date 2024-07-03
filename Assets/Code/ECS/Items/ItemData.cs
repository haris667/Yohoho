using UnityEngine;
using UnityEngine.UI;

namespace ECS.Items
{
    [System.Serializable]
    struct ItemData 
    {
        public int id;
        public string name;
        public Image icon;
        public Material material;
        public ItemType type;
    }

    public enum ItemType
    {
        Red,
        Blue,
        Yellow
    }
}