using Audio;
using Cannon.Bullets;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Core
{
    public class Game : MonoBehaviour
    {
        private const float TIME_BEFORE_LOSE = 5f;
        private RoundListener _roundListener;
        private AudioMediator _audioController;

        [Inject]
        public void Construct(RoundListener roundListener, AudioMediator audioController)
        {
            BulletController.OnBulletEnd += Lose;
            _roundListener = roundListener;
            _audioController = audioController;
            RoundListener.OnLevelWin += Win;
            RoundListener.OnRoundWin += Win;
        }



        private void OnDestroy()
        {
            BulletController.OnBulletEnd -= Lose;
            RoundListener.OnLevelWin -= Win;
            RoundListener.OnRoundWin -= Win;
        }

        public void ResetRound()
        {
            PlayerPrefs.SetInt("Round", 0);
            _audioController.Expose();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void Win()
        {
            StopAllCoroutines();
        }

        private void Lose()
        {
            StartCoroutine(LastChance());
        }

        private IEnumerator LastChance()
        {
            yield return new WaitForSeconds(TIME_BEFORE_LOSE);
            _audioController.Expose();
            _roundListener.ShowLoseMenu();
        }
    }
}