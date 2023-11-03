using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Level
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private List<Image> cells;
        [SerializeField] private TextMeshProUGUI nextRoundCell;
        [SerializeField] private TextMeshProUGUI currentRoundCell;

        public List<Image> Cells => cells;

        public void SetCurrentRound(int round) => currentRoundCell.text = $"{round}";
        public void SetNextRound(int round) => nextRoundCell.text = $"{round}";
    }
}