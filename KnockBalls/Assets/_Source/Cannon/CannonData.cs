using UnityEngine;

namespace Cannon
{
    public class CannonData : MonoBehaviour
    {
        [SerializeField] private float fireForce;
        [SerializeField] private Transform firePoint;
        [SerializeField] private Transform cannonTransform;
        [SerializeField] private LayerMask enviromentLayerMask;


        public float FireForce => fireForce;
        public Transform FirePoint => firePoint;
        public Transform CannonTransform => cannonTransform;
        public LayerMask EnviromentLayerMask => enviromentLayerMask;
    }
}