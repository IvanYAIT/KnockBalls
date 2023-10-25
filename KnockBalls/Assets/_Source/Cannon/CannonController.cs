using Cannon.Bullets;
using UnityEngine;
using Zenject;

namespace Cannon
{
    public class CannonController
    {
        private BulletPool _pool;

        [Inject]
        public CannonController(BulletPool pool)
        {
            _pool = pool;
        }

        public void Rotate(Transform cannonTransform, RaycastHit hitInfo)
        {
            Vector3 dir = hitInfo.point - cannonTransform.position;
            cannonTransform.rotation = Quaternion.LookRotation(dir);
        }

        public void Fire(Transform firePoint, float fireForce)
        {
            Bullet bullet = _pool.GetFreeElement();
            bullet.gameObject.transform.position = firePoint.position;
            bullet.gameObject.transform.rotation = firePoint.rotation;
            bullet.Shoot(firePoint.forward, fireForce);
        }
    }
}