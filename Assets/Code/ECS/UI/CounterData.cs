using ECS.Items;
using TMPro;

namespace ECS.UI
{
    [System.Serializable]
    public struct CounterData 
    {
        public TextMeshProUGUI text;
        public int count;
        public ItemType type;
    }
}