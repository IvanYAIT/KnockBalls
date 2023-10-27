using System;
using System.Collections;
using System.Collections.Generic;
using Cannon.Bullets;
using Level;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class RoundListener : MonoBehaviour
{
    private List<LevelSettings> _roundSetting;
    private Transform PositionOfLevels;
    private int _counter = 0;
    private GameObject LastRound;
    private BulletController _activeController;
    private BulletView _view;
    public GameObject UI;
    public RoundController TriggerZone;
    
    
    [Inject]
    public void Construct(RoundSettings rounds, BulletView view, Transform levelsPosition)
    {
        _roundSetting = rounds.Levels;
        _view = view;
        PositionOfLevels = levelsPosition;
        SpawnFirstLevel();
    }

    public void GoNextRound()
    {
        if (_counter == _roundSetting.Count)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        LastRound.SetActive(false);
        _activeController = new BulletController(_roundSetting[_counter],_view);
        LastRound = Instantiate(_roundSetting[_counter].LevelPrefab, PositionOfLevels);
        TriggerZone.SetParameters(_roundSetting[_counter].AmountOfBlocks, this);
        _counter++;
    }
    
    public void SpawnFirstLevel()
    {
        LastRound = Instantiate(_roundSetting[0].LevelPrefab, PositionOfLevels);
        _activeController = new BulletController(_roundSetting[0],_view);
        TriggerZone.SetParameters(_roundSetting[0].AmountOfBlocks, this);
        _counter++;
    }

    public void ShowUI()
    {
        UI.SetActive(true);
    }

    
    
}
