using System;
using _game.Scripts.Utilities;
using UnityEngine;

namespace _game.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public static GameManager Instance { get; private set; }
        public static event Action OnLevelInitialized, OnLevelStart, OnLevelFailed, OnLevelCompleted;

        private void Start()
        {
            InitializeLevel();
        }

        private static void InitializeLevel()
        {
            OnLevelInitialized?.Invoke();
        }

        public void LevelStart()
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
