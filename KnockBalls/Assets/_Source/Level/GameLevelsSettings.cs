using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoundSettings", menuName = "SO/NewGameLevelSettings")]
public class GameLevelsSettings : ScriptableObject
{
    [SerializeField] private List<RoundSettings> _rounds;
    
    public List<RoundSettings> Rounds => _rounds;
}
