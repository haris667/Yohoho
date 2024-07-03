using ECS.Player;
using ECS.Player.Camera;
using Leopotam.Ecs;
using SO;
using UnityEngine;
using LeoEcsPhysics;
using Voody.UniLeo;
using ECS.Player.Baggage;

namespace ECS
{
    sealed class EcsStartup : MonoBehaviour 
    {
        EcsWorld _world;
        EcsSystems _systems;
        EcsSystems _fixedSystems;

        public PlayerConfig playerConfig;
        public CameraConfig cameraConfig;
        public Camera camera;

        void Start() 
        {            
            _world = new EcsWorld();
            EcsPhysicsEvents.ecsWorld = _world;

            _systems = new EcsSystems (_world);
            _fixedSystems = new EcsSystems(_world);
            
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_fixedSystems);
#endif
            _systems
                .ConvertScene()
                .Init ();

            _fixedSystems
                .ConvertScene()
                .Add(new PlayerMoveSystem())
                .Add(new CameraMoveSystem())
                .Add(new BaggageSystem())

                .OneFramePhysics()

                .Inject(camera)
                .Inject(cameraConfig)
                .Inject(playerConfig)

                .Init();
        }

        void Update() => _systems?.Run();

        void FixedUpdate() => _fixedSystems?.Run();

        void OnDestroy() 
        {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}