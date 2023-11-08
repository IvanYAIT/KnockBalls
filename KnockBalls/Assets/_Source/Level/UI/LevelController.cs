using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Level
{
    public class LevelController
    {
        private LevelView _view;
        private int _currentLevel;

        [Inject]
        public LevelController(LevelView view)
        {
            _view = view;
            _currentLevel = 0;
        }

        public void NextLevel()
        {
            if(_currentLevel < _view.Cells.Count)
                _view.Cells[_currentLevel].color = Color.yellow;
            _currentLevel++;
        }

        public void NextRound(int round)
        {
            _view.SetCurrentRound(round);
            _view.SetNextRound(round + 1);
            _currentLevel = 0;
            foreach (Image cell in _view.Cells)
                cell.color = Color.white;
        }
    }
}