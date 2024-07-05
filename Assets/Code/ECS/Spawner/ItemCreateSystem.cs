using ECS.Events;
using LeoEcsPhysics;
using Leopotam.Ecs;
using SO;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace ECS.Spawner
{
    public class ItemCreateSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private EcsFilter<ItemSpawnData> _spawnFilter;
        private EcsFilter<GetItemEvent> _eventFilter;
        private SpawnerConfig _config;

        private GameObject _lastCreatedGO;
        private bool _created;
        
        void IEcsRunSystem.Run () 
        {
            foreach (var i in _spawnFilter)
            {
                ref var spawnData = ref _spawnFilter.Get1(i);
                if (!spawnData.used) Create(spawnData, i);
                spawnData.createdObject = _lastCreatedGO;
                spawnData.used = true;
            }
        }
        private async void Create(ItemSpawnData spawnData, int amount)
        {
            await Task.Delay(TimeSpan.FromSeconds(_config.timeIteration * amount));
            //хотел реализовать пулинг, но я и так задерживаю сильно со сроками, извините
            _lastCreatedGO = GameObject.Instantiate(ChooseGameObjectRand(_config.prefabs), spawnData.transform.position, Quaternion.identity);
        }

        private GameObject ChooseGameObjectRand(GameObject[] prefabs)
        {
            return prefabs[UnityEngine.Random.Range(0, prefabs.Length)];
        }
    }
}