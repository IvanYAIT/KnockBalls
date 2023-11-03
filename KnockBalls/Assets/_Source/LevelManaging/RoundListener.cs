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
    public static Action OnLevelWin;
    public static Action OnRoundWin;

    private List<LevelSettings> _activeRoundSetting;
    private Transform PositionOfLevels;
    private int _levelCounter = 0;
    private GameObject _lastRound;
    private BulletController _activeController;
    private LevelController _levelController;
    public GameObject winScreen;
    public GameObject loseScreen;
    public RoundController TriggerZone;
    public ScreenFader Fader;
    private int _roundIndex;
    
    [Inject]
    public void Construct(BulletController controller, Transform levelsPosition, ScreenFader fader, LevelController levelController)
    {
        _levelController = levelController;
        _roundIndex = PlayerPrefs.GetInt("Round", 0);
        _levelController.NextRound(_roundIndex);
        _activeController = controller;
        PositionOfLevels = levelsPosition;
        Fader = fader;
        getNextRound();
        SpawnFirstLevel();
    }

    public void GoNextLevel()
    {
        _levelController.NextLevel();
        if (_levelCounter == _activeRoundSetting.Count)
        {
            OnRoundWin?.Invoke();
            ShowUI();
        }
        else
        {
            Fader.FadeIn().OnComplete(() =>
            {
                OnLevelWin?.Invoke();
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
        PlayerPrefs.SetInt("Round", _roundIndex);
        _levelController.NextRound(_roundIndex);
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
        //_roundIndex = 0;
        //getNextRound();
        SpawnFirstLevel();
    }
    
    public void ShowUI()=>
        winScreen.SetActive(!winScreen.activeSelf);


    public void ShowLoseMenu()=>
        loseScreen.SetActive(!loseScreen.activeSelf);


    public void TurnOffUI()
    {
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
    }


    private void getNextRound()
    {
        _activeRoundSetting = RoundsInfo.RoundSettingsList[_roundIndex].Levels;
        _levelCounter = 0;
        _roundIndex++;
    }
}
