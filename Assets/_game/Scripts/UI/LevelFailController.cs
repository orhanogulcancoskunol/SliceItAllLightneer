using _game.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace _game.Scripts.UI
{
    public class LevelFailController : CanvasController<LevelFailController>
    {
        public Button RestartButton;

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
            RestartButton.onClick.AddListener(GameManager.Instance.RestartLevel);
        }
    }
}
