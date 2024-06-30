using ECS.BaseComponents;
using ECS.Tags;
using Leopotam.Ecs;
using SO;
using UnityEngine;

namespace ECS.Player
{
    sealed class PlayerMoveSystem : IEcsRunSystem
    {
        private EcsFilter<InputData, TransformData, RigidbodyData, PlayerTag> _filter;
        private readonly EcsWorld _world = null;

        private PlayerConfig _playerConfig;

        private Vector2 _directionMove;
        private Rigidbody _rigidbody;
        private Transform _transform;

        void IEcsRunSystem.Run () 
        {
            foreach(var i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);
                _directionMove = entity.Get<InputData>().joystick.Direction;
                _rigidbody = entity.Get<RigidbodyData>().rigidbody;
                _transform = entity.Get<TransformData>().transform;

                Move(_rigidbody, _transform, _directionMove);
                Rotate(_transform, _directionMove);
            }
        }

        private void Move(Rigidbody rigid, Transform transform, Vector2 direction)
        {
            if (direction.magnitude <= 0.1f) return;

            rigid.AddForce(transform.forward * _playerConfig.speed);
        }

        private void Rotate(Transform transform, Vector2 direction)
        {
            if (direction.magnitude <= 0.1f) return;
            
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, Time.deltaTime * _playerConfig.turnSpeed);

            transform.rotation = Quaternion.Euler(0, angle, 0);  
        }
    }
}