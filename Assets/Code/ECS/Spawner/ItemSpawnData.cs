using ECS.Spawner.Helper;
using UnityEngine;

namespace ECS.Spawner
{
    [System.Serializable]
    public struct ItemSpawnData 
    {
        public Transform transform;
        public bool used;
        public GameObject createdObject;
        public AddTagHelper helper;
    }
}