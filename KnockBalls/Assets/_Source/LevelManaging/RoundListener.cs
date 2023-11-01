using System;
using System.Collections;
using System.Collections.Generic;
using _Source.LevelManaging;
using Cannon.Bullets;
using DG.Tweening;
using Level;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class RoundListener : MonoBehaviour
{
    private List<LevelSettings> _activeRoundSetting;
    private Transform PositionOfLevels;
    private int _levelCounter = 0;
    private GameObject _lastRound;
    private BulletController _activeController;
    private BulletView _view;
    public GameObject UI;
    public RoundController TriggerZone;
    public ScreenFader Fader;
    private int _roundIndex = 0;
    
    [Inject]
    public void Construct(BulletController controller, Transform levelsPosition, ScreenFader fader)
    {
        _activeController = controller;
        PositionOfLevels = levelsPosition;
        Fader = fader;
        getNextRound();
        SpawnFirstLevel();
    }

    public void GoNextLevel()
    {
        if (_levelCounter == _activeRoundSetting.Count)
        {
            ShowUI();
        }
        else
        {
            Fader.FadeIn().OnComplete(() =>
            {
                _lastRound.SetActive(false);
                _activeController.Reset(_activeRoundSetting[_levelCounter]);
                _lastRound = Instantiate(_activeRoundSetting[_levelCounter].LevelPrefab, PositionOfLevels);
                TriggerZone.SetBolckCount(_activeRoundSetting[_levelCounter].AmountOfBlocks);
                _levelCounter++;
                Fader.FadeOut();
            });
            
        }
    }

    public void GoNextRound()
    {
        getNextRound();
        SpawnFirstLevel();
    }
    
    public void SpawnFirstLevel()
    {
        _lastRound = Instantiate(_activeRoundSetting[0].LevelPrefab, PositionOfLevels);
        _activeController.Reset(_activeRoundSetting[0]);
        TriggerZone.SetListener(this);
        TriggerZone.SetBolckCount(_activeRoundSetting[0].AmountOfBlocks);
        _levelCounter++;
    }

    public LevelSettings GetActiveLevelSettings()
    {
        return _activeRoundSetting[_levelCounter - 1];
    }


    public void RestartRound()
    {
        _roundIndex = 0;
        getNextRound();
        SpawnFirstLevel();
    }
    
    public void ShowUI()
    {
        UI.SetActive(!UI.activeSelf);
    }

    private void getNextRound()
    {
        Debug.Log(_roundIndex);
        _activeRoundSetting = RoundsInfo.RoundSettingsList[_roundIndex].Levels;
        _levelCounter = 0;
        _roundIndex++;
    }
}
