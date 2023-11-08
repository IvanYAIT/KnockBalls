using UnityEngine;

namespace Audio
{
    public class AudioData : MonoBehaviour
    {
        [SerializeField] private AudioSource cannonSource;
        [SerializeField] private AudioSource hitSource;
        [SerializeField] private AudioSource boxHitSource;

        public AudioSource CannonSource => cannonSource;
        public AudioSource HitSource => hitSource;
        public AudioSource BoxHitSource => boxHitSource;
    }
}