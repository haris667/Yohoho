using LeoEcsPhysics;

namespace ECS.Services 
{
    public class CollisionCheckService
    {
        public bool CheckCollisionObjects(OnTriggerEnterEvent eventData, string senderTag, string collidedTag)
        {
            return eventData.collider.CompareTag(senderTag) && eventData.senderGameObject.CompareTag(collidedTag);
        }
    }
}