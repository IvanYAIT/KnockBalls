using Audio;
using System.Collections;
using UnityEngine;

namespace Cannon.Bullets
{
    public class Bullet : MonoBehaviour
    {
        private const int LIFE_TIME = 5;

        [SerializeField] private Rigidbody rb;
        [SerializeField] private LayerMask blockLayerMask;

        private int _blockLayer;

        private void Start()
        {
            _blockLayer = (int)Mathf.Log(blockLayerMask.value, 2);
        }

        private void OnEnable()
        {
            StartCoroutine(LifeTime());
        }

        private void OnDisable()
        {
            rb.velocity *= 0;
            transform.rotation = new Quaternion();
            transform.position = new Vector3();
        }

        private void OnCollisionEnter(Collision collision)
        {
            AudioMediator.OnBulletHit?.Invoke();
        }

        public void Shoot(Vector3 dir, float force)
        {
            rb.AddForce(dir * force, ForceMode.Impulse);
        }

        private IEnumerator LifeTime()
        {
            yield return new WaitForSeconds(LIFE_TIME);
            gameObject.SetActive(false);
        }
    }
}