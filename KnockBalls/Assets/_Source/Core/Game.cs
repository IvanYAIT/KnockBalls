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
        public RoundListener _roundListener;

        [Inject]
        public void Construct(RoundListener roundListener)
        {
            BulletController.OnBulletEnd += Lose;
            _roundListener = roundListener;
            RoundListener.OnLevelWin += Win;
            RoundListener.OnRoundWin += Win;
        }



        private void OnDestroy()
        {
            BulletController.OnBulletEnd -= Lose;
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
            _roundListener.ShowLoseMenu();
        }
    }
}