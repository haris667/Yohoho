using ECS.Tags;
using ECS.Tags.Providers;
using Leopotam.Ecs;
using System;
using UnityEngine;
using Voody.UniLeo;

namespace ECS.Spawner.Helper
{
    public class AddTagHelper : MonoBehaviour
    {
        public Action onCollided;

        private void OnTriggerEnter(Collider other)
        {
            onCollided?.Invoke();
        }
    }
}
