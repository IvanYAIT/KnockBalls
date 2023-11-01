using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Source.LevelManaging
{
    public class RoundsInfo
    {
        public static List<RoundSettings> RoundSettingsList;
        
        [Inject]
        public void Construct(GameLevelsSettings gameLevelsSettings)
        {
            RoundSettingsList = gameLevelsSettings.Rounds;
        }
    }
}