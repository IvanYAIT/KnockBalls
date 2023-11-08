using System;
using UnityEngine;
using Zenject;

namespace Audio
{
    public class AudioSettings
    {
        public static Action OnPanleClose;
        public static Action OnPanleOpen;

        private AudioSettingsView _view;

        [Inject]
        public AudioSettings(AudioSettingsView view)
        {
            _view = view;
            _view.OpenSettingsBtn.onClick.AddListener(ShowPanel);
            _view.CloseSettingsBtn.onClick.AddListener(ClosePanel);
        }

        private void ClosePanel()
        {
            _view.SettingsPanel.SetActive(false);
            Time.timeScale = 1;
            OnPanleClose?.Invoke();
        }

        private void ShowPanel()
        {
            _view.SettingsPanel.SetActive(true);
            Time.timeScale = 0;
            OnPanleOpen?.Invoke();
        }

        public void Expose()
        {
            _view.OpenSettingsBtn.onClick.RemoveListener(ShowPanel);
            _view.CloseSettingsBtn.onClick.RemoveListener(ClosePanel);
        }
    }
}