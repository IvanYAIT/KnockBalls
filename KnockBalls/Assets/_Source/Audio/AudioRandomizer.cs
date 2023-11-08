using UnityEngine;

namespace Audio
{
    public class AudioRandomizer
    {
        private AudioClipData _audioClipData;

        public AudioRandomizer(AudioClipData audioClipData)
        {
            _audioClipData = audioClipData;
        }

        public AudioClip RandomizeFireSound() => 
            _audioClipData.FiresVariants[Random.Range(0, _audioClipData.FiresVariants.Count)];

        public AudioClip RandomizeHitSound() =>
            _audioClipData.BoxHitsVariants[Random.Range(0, _audioClipData.BoxHitsVariants.Count)];
    }
}