using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Audio
{
    public class SoundChanger : MonoBehaviour
    {
        private const string MUSIC_VOLUME = "Music";
        private const string SFX_VOLUME = "SFX";

        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;
        [SerializeField] private AudioMixer mixer;

        private void OnEnable()
        {
            musicSlider.value = PlayerPrefs.GetFloat(MUSIC_VOLUME);
            sfxSlider.value = PlayerPrefs.GetFloat(SFX_VOLUME);

            musicSlider.onValueChanged.AddListener(ChangeMusic);
            sfxSlider.onValueChanged.AddListener(ChangeSFX);
        }

        public void ChangeSFX(float value)
        {
            if (value > 0)
                mixer.SetFloat(SFX_VOLUME, Mathf.Log10(value) * 30);
            else
                mixer.SetFloat(SFX_VOLUME, -80);

            PlayerPrefs.SetFloat(SFX_VOLUME, sfxSlider.value);
        }

        public void ChangeMusic(float value)
        {
            if (value > 0)
                mixer.SetFloat(MUSIC_VOLUME, Mathf.Log10(value) * 30);
            else
                mixer.SetFloat(MUSIC_VOLUME, -80);

            PlayerPrefs.SetFloat(MUSIC_VOLUME, musicSlider.value);
        }
    }
}