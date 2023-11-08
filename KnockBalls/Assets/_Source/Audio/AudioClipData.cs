using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(fileName = "AudioClipData",menuName = "SO/NewAudioClipData")]
    public class AudioClipData : ScriptableObject
    {
        [SerializeField] private List<AudioClip> firesVariants;
        [SerializeField] private List<AudioClip> boxHitsVariants;

        public List<AudioClip> FiresVariants => firesVariants;
        public List<AudioClip> BoxHitsVariants => boxHitsVariants;
    }
}