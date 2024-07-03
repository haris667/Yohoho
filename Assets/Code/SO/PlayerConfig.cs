using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/PlayerConfig", order = 3)]
    public class PlayerConfig : ScriptableObject
    {
        public float speed;
        public float turnSpeed;
    }
    
}
