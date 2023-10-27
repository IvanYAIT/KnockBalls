using Cannon.Bullets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Core
{
    public class Game : MonoBehaviour
    {
        private const float TIME_BEFORE_LOSE = 5f;
        public RoundListener _roundListener;

        private bool isLose;

        [Inject]
        public void Construct()
        {
            BulletController.OnBulletEnd += Lose;
        }

        private void OnDestroy()
        {
            BulletController.OnBulletEnd -= Lose;
        }

        private void Lose()
        {
            isLose = true;
            StartCoroutine(LastChance());
        }

        private IEnumerator LastChance()
        {
            yield return new WaitForSeconds(TIME_BEFORE_LOSE);
            if (isLose)
                _roundListener.ShowUI();
        }
    }
}