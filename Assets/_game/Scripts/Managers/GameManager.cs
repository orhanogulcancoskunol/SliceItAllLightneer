using System;
using _game.Scripts.Utilities;
using UnityEngine;

namespace _game.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public static event Action OnLevelInitialized, OnLevelStart, OnLevelFailed, OnLevelCompleted;

        private bool _isPlaying;
        private void Start()
        {
            InitializeLevel();
        }

        private void InitializeLevel()
        {
            _isPlaying = false;
            CharacterManager.Instance.Initialize();
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

        private void LevelStart()
        {
            OnLevelStart?.Invoke();
        }

        public void LevelFail()
        {
            OnLevelFailed?.Invoke();
        }

        public void LevelComplete()
        {
            OnLevelCompleted?.Invoke();
        }
    }
}
