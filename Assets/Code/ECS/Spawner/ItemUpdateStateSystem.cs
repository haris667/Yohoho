using ECS.Events;
using Leopotam.Ecs;
using SO;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace ECS.Spawner
{
    sealed class ItemUpdateStateSystem : IEcsRunSystem 
    {
        private readonly EcsWorld _world = null;
        private EcsFilter<ItemSpawnData> _spawnFilter;
        private EcsFilter<GetItemEvent> _eventFilter;

        void IEcsRunSystem.Run()
        {
            
            foreach (var i in _eventFilter)
            {
                foreach (var j in _spawnFilter)
                {
                    ref var spawnData = ref _spawnFilter.Get1(j);
                    if (spawnData.used && spawnData.createdObject == null) spawnData.used = false;
                }
            }
        }
    }
}