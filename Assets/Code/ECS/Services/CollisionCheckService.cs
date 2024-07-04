using ECS.BaseComponents;
using ECS.Items;
using LeoEcsPhysics;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Services 
{
    public class CollisionCheckService
    {
        public bool CheckCollisionObjects(OnTriggerEnterEvent eventData, string senderTag, string collidedTag)
        {
            return eventData.collider.CompareTag(senderTag) && eventData.senderGameObject.CompareTag(collidedTag);
        }

        //вообще говоря, реализация меня смущает, скорее всего есть решение лучше. А вполне вероятно сама концепция метода некорректная
        //плюсом можно использовать только когда есть уверенность в нахождении сущности
        public EcsEntity FindEntityWithCollision(OnTriggerEnterEvent eventData, EcsFilter<ItemData, TransformData> itemsFilter)
        {
            foreach(var i in itemsFilter)
            {
                ref var entity = ref itemsFilter.GetEntity(i);
                Transform transform = entity.Get<TransformData>().transform;

                if (eventData.collider.transform == transform) return entity;
            }
            throw new System.Exception("FindEntityWithCollision - entity не найден");
        }
    }
}