using Audio;
using UnityEngine;

namespace Level
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private LayerMask blockLayerMask;

        private int blockLayer;

        private void Start()
        {
            blockLayer = (int)Mathf.Log(blockLayerMask.value, 2);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.layer != blockLayer)
                AudioMediator.OnBoxHit?.Invoke();
        }
    }
}