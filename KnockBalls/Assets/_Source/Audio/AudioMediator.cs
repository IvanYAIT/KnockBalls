using System;
using UnityEngine;
using Zenject;

namespace Audio
{
    public class AudioMediator
    {
        public static Action OnShoot;
        public static Action OnBulletHit;
        public static Action OnBoxHit;

        private AudioData _data;
        private AudioRandomizer _randomizer;

        [Inject]
        public AudioMediator(AudioData data, AudioRandomizer audioRandomizer)
        {
            _data = data;
            _randomizer = audioRandomizer;
            OnShoot += PlayShootSound;
            OnBulletHit += PlayBulletHitSound;
            OnBoxHit += PlayBoxHitSound;
        }

        private void PlayShootSound()
        {
            _data.CannonSource.clip = _randomizer.RandomizeFireSound();
            _data.CannonSource.Play();
        }

        private void PlayBoxHitSound()
        {
            _data.BoxHitSource.clip = _randomizer.RandomizeHitSound();
            _data.BoxHitSource.Play();
        }

        private void PlayBulletHitSound() =>
            _data.HitSource.Play();

        public void Expose()
        {
            OnShoot -= PlayShootSound;
            OnBulletHit -= PlayBulletHitSound;
            OnBoxHit -= PlayBoxHitSound;
        }
    }
}