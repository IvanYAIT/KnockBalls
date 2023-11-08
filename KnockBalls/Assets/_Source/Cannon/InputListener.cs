using _Source.LevelManaging;
using Audio;
using Cannon.Bullets;
using Cannon.Skill;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Cannon
{
    public class InputListener : MonoBehaviour
    {
        private const int SKILL_DURATION = 5;
        private const float SHOOT_COOLDOWN = 0.2f;

        private CannonData _data;
        private CannonController _controller;
        private BulletController _bulletController;
        private int _enviromentLayer;
        private bool input;
        private bool skill;
        private bool cooldown;

        [Inject]
        public void Construct(CannonData data, CannonController controller, BulletController bulletController)
        {
            input = true;
            _data = data;
            _controller = controller;
            _bulletController = bulletController;
            _enviromentLayer = 1<<(int)Mathf.Log(data.EnviromentLayerMask.value, 2);
            BulletController.OnBulletEnd += DisableInput;
            RoundListener.OnLevelWin += EnableInput;
            RoundListener.OnRoundWin += DisableInput;
            LevelTransitionController.OnBtnClick += EnableInput;
            Audio.AudioSettings.OnPanleClose += EnableInput;
            Audio.AudioSettings.OnPanleOpen += DisableInput;
            SkillController.OnSkillUse += UseSkill;
        }

        void Update()
        {
            if (!skill)
            {
                if (Input.GetMouseButtonDown(0) && input)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _enviromentLayer))
                    {
                        _controller.Rotate(_data.CannonTransform, hitInfo);
                        _bulletController.UseBullet();
                        _controller.Fire(_data.FirePoint, _data.FireForce);
                        Vibration.Vibrate(50);
                        AudioMediator.OnShoot?.Invoke();
                    }
                }
            }
            else
            {
                if (Input.GetMouseButton(0) && input)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _enviromentLayer))
                    {
                        if (!cooldown)
                        {
                            _controller.Rotate(_data.CannonTransform, hitInfo);
                            StartCoroutine(Minigun());
                        }
                    }
                }
            }
            
        }



        private void OnDestroy()
        {
            BulletController.OnBulletEnd -= DisableInput;
            RoundListener.OnLevelWin -= EnableInput;
            RoundListener.OnRoundWin -= DisableInput;
            LevelTransitionController.OnBtnClick -= EnableInput;
            Audio.AudioSettings.OnPanleClose -= EnableInput;
            Audio.AudioSettings.OnPanleOpen -= DisableInput;
            SkillController.OnSkillUse -= UseSkill;
        }

        private void UseSkill() =>
            StartCoroutine(SkillTime());

        private IEnumerator SkillTime()
        {
            skill = true;
            yield return new WaitForSeconds(_data.SkillDuration);
            skill = false;
        }

        private IEnumerator Minigun()
        {
            _controller.Fire(_data.FirePoint, _data.FireForce);
            AudioMediator.OnShoot?.Invoke();
            Handheld.Vibrate();
            cooldown = true;
            yield return new WaitForSeconds(_data.SkillShootCooldown);
            cooldown = false;
        }

        public void EnableInput() => input = true;
        public void DisableInput() => input = false;
    }
}