using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemsConfig", order = 1)]
    public class ItemsConfig : ScriptableObject
    {
        public ItemConfig[] config;
    }

    [System.Serializable]
    public struct ItemConfig
    {
        public int id;
        public string name;
        public Sprite icon;
        public Material material;
    }
}
