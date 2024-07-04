using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "BaggageConfig", menuName = "ScriptableObjects/BaggageConfig", order = 4)]
    public class BaggageConfig : ScriptableObject
    {
        public Vector3 shift;
        public int maxAmount;
        public float shakingCoef;
        public float increasingNewItem;
        public GameObject prefab;
    }
}
