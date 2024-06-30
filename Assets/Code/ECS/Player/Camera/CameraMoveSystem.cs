using ECS.BaseComponents;
using ECS.Tags;
using Leopotam.Ecs;
using SO;
using UnityEngine;

namespace ECS.Player.Camera
{
    sealed class CameraMoveSystem : IEcsRunSystem 
    {
        private EcsFilter<TransformData, PlayerTag> _filter;
        private readonly EcsWorld _world = null;

        private CameraConfig _cameraConfig;
        private UnityEngine.Camera camera;

        private Transform _playerTransform;
        private Vector3 _targetPosition;
        
        void IEcsRunSystem.Run () 
        {
            foreach(var i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);
                _playerTransform = entity.Get<TransformData>().transform;

                Move();
            }
        }

        private void Move()
        {
            _targetPosition = _playerTransform.position + _cameraConfig.shift;
            camera.transform.position = Vector3.Lerp(camera.transform.position, _targetPosition, 0.02f * _cameraConfig.speed);
        }
    }
}