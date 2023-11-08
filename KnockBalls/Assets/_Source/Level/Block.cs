using Audio;
using UnityEngine;

namespace Level
{
    public class Block : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            AudioMediator.OnBoxHit?.Invoke();
        }
    }
}