using UnityEngine;

namespace Cannon
{
    public class CannonData : MonoBehaviour
    {
        [SerializeField] private float fireForce;
        [SerializeField] private Transform firePoint;
        [SerializeField] private Transform cannonTransform;
        [SerializeField] private LayerMask enviromentLayerMask;
        [SerializeField] private float skillShootCooldown;
        [SerializeField] private int skillDuration;


        public float FireForce => fireForce;
        public float SkillShootCooldown => skillShootCooldown;
        public int SkillDuration  => skillDuration;
        public Transform FirePoint => firePoint;
        public Transform CannonTransform => cannonTransform;
        public LayerMask EnviromentLayerMask => enviromentLayerMask;
    }
}