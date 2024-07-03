using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "ScriptableObjects/CameraConfig", order = 2)]
    public class CameraConfig : ScriptableObject
    {
        public Vector3 shift;
        public float speed;
    }
    
}
