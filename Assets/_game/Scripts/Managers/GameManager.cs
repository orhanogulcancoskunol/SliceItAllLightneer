using System;
using _game.Scripts.ScriptableObjects;
using _game.Scripts.UI;
using _game.Scripts.Utilities;
using UnityEngine;

namespace _game.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public static event Action OnLevelInitialized, OnLevelStart, OnLevelFailed, OnLevelCompleted;
        public LevelListSO LevelList;

        private int _currentLevel=1;
        private bool _isPlaying;
        private void Start()
        {
            InitializeLevel();
        }

        private void InitializeLevel()
        {
            _isPlaying = false;
            MapManager.Instance.SpawnMap(LevelList.Levels[_currentLevel%LevelList.Levels.Count].LevelPrefab);
            CharacterManager.Instance.Initialize();
            IntroLevelCanvasController.Instance.Show();
            LevelCompleteCanvasController.Instance.Hide();
            InLevelCanvasController.Instance.Hide();
            LevelFailController.Instance.Hide();
            OnLevelInitialized?.Invoke();
        }

        private void Update()
        {
            if (_isPlaying)
                return;
            if (!Input.GetMouseButtonDown(0)) return;
            _isPlaying = true;
            LevelStart();
        }

        private static void LevelStart()
        {
            IntroLevelCanvasController.Instance.Hide();
            LevelCompleteCanvasController.Instance.Hide();
            LevelFailController.Instance.Hide();
            InLevelCanvasController.Instance.Show();
            OnLevelStart?.Invoke();
        }

        public static void LevelFail()
        {
            IntroLevelCanvasController.Instance.Hide();
            LevelCompleteCanvasController.Instance.Hide();
            InLevelCanvasController.Instance.Hide();
            LevelFailController.Instance.Show();
            OnLevelFailed?.Invoke();
        }

        public void LevelComplete()
        {
            IntroLevelCanvasController.Instance.Hide();
            LevelCompleteCanvasController.Instance.Show();
            LevelFailController.Instance.Hide();
            InLevelCanvasController.Instance.Hide();
            OnLevelCompleted?.Invoke();
            _currentLevel++;
        }

        public void RestartLevel()
        {
            InitializeLevel();
        }
    }
}
