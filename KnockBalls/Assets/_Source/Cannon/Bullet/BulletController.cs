using Level;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Cannon.Bullets
{
    public class BulletController
    {
        public static Action OnBulletEnd;

        private int _currentAmountOfBullets;
        private BulletView _view;

        
        public BulletController(LevelSettings levelSettings, BulletView view)
        {
            _currentAmountOfBullets = levelSettings.AmountOfBullets;
            _view = view;
            _view.SetBulletText($"{_currentAmountOfBullets}");
            
        }

        public void UseBullet()
        {
            _currentAmountOfBullets--;

            if (_currentAmountOfBullets <= 0)
            {
                OnBulletEnd?.Invoke();
                _view.SetBulletText("0");
                return;
            }

            _view.SetBulletText($"{_currentAmountOfBullets}");
        }
    }
}