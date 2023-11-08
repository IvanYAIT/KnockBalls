using _Source.LevelManaging;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Cannon.Skill
{
    public class SkillController
    {
        public static Action OnSkillUse;

        private SkillView _view;

        [Inject]
        public SkillController(SkillView view)
        {
            _view = view;
            _view.SkillBtn.onClick.AddListener(UseSkill);
            LevelTransitionController.OnBtnClick += ResetSkill;
        }

        public void UseSkill()
        {
            OnSkillUse?.Invoke();
            _view.SkillBtn.interactable = false;
        }

        public void ResetSkill() =>
            _view.SkillBtn.interactable = true;
    }
}