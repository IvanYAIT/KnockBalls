using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Source.LevelManaging
{
    public class LevelTransitionController : MonoBehaviour
    {
        public static Action OnBtnClick;

        private RoundListener _listener;
        private ScreenFader _fader;

        [Inject]
        public void Construct(RoundListener listener)
        {
            _listener = listener;
            _fader = listener.Fader;
        }

        public void GoNextRound()
        {
            OnBtnClick?.Invoke();
            _listener.TurnOffUI();
            _fader.FadeIn().OnComplete(() =>
            {
                _listener.GoNextRound();
                _fader.FadeOut();
            });
        }

        public void RestartActiveRound()
        {
            OnBtnClick?.Invoke();
            _listener.TurnOffUI();
            _fader.FadeIn().OnComplete(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //_listener.RestartRound();
                //_fader.FadeOut();
            });
        }

        public void GoToMenu()
        {
            OnBtnClick?.Invoke();
            _listener.TurnOffUI();
            _fader.FadeIn().OnComplete(() =>
            {
                SceneManager.LoadScene(0);
            });
        }
    }
}