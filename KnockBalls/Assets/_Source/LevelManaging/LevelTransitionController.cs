using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Source.LevelManaging
{
    public class LevelTransitionController : MonoBehaviour
    {
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
            _fader.FadeIn().OnComplete(() =>
            {
                _listener.ShowUI();
                _listener.GoNextRound();
                _fader.FadeOut();
            });
        }

        public void RestartActiveRound()
        {
            _fader.FadeIn().OnComplete(() =>
            {
                _listener.ShowUI();
                _listener.RestartRound();
                _fader.FadeOut();
            });
        }

        public void GoToMenu()
        {
            _fader.FadeIn().OnComplete(() =>
            {
                SceneManager.LoadScene(0);
            });
        }
    }
}