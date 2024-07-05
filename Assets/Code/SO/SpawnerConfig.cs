using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "SpawnerConfig", menuName = "ScriptableObjects/SpawnerConfig", order = 5)]
    public class SpawnerConfig : ScriptableObject
    {
        public GameObject[] prefabs;
        public float timeIteration;
    }
}