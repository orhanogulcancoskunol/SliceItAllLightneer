using System;
using _game.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _game.Scripts.UI
{
    public class LevelCompleteCanvasController : CanvasController<LevelCompleteCanvasController>
    {
        public Button NextLevelButton;
        public TextMeshProUGUI Score;

        private void OnEnable()
        {
            GameManager.OnLevelInitialized += AddButtonListener;
        }

        private void OnDisable()
        {
            GameManager.OnLevelInitialized -= AddButtonListener;
        }

        private void AddButtonListener()
        {
            NextLevelButton.onClick.AddListener(GameManager.Instance.RestartLevel);
        }
    }
}
