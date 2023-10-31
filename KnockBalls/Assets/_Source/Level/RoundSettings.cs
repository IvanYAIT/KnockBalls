using System.Collections;
using System.Collections.Generic;
using Level;
using UnityEngine;

[CreateAssetMenu(fileName = "RoundSettings", menuName = "SO/NewRoundSettings")]
public class RoundSettings : ScriptableObject
{
    [SerializeField] private List<LevelSettings> _levels;
    
    public List<LevelSettings> Levels => _levels;
}
