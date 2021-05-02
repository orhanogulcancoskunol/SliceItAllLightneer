using System;
using _game.Scripts.Managers;
using _game.Scripts.UI;
using UnityEngine;

namespace _game.Scripts.Character
{
    public class SwordScoreController : MonoBehaviour
    {
        public delegate void OnHit(int num);
        
        public OnHit OnObstacle, OnEndLevel;

        private SwordPolishController _polishController;
        private int _totalScore;

        private void Awake()
        {
            _polishController = GetComponent<SwordPolishController>();
        }

        private void OnEnable()
        {
            GameManager.OnLevelInitialized += ResetScore;
            OnObstacle += AddScorePolish;
            OnObstacle += AddScore;
            OnObstacle += UpdateUIScore;
            OnEndLevel += ScoreMultiply;
            OnEndLevel += UpdateEndUIScore;
        }

        private void OnDisable()
        {
            GameManager.OnLevelInitialized -= ResetScore;
            OnObstacle -= AddScorePolish;
            OnObstacle -= AddScore;
            OnObstacle -= UpdateUIScore;
            OnEndLevel -= UpdateEndUIScore;
            OnEndLevel -= ScoreMultiply;
        }

        private void ScoreMultiply(int multiply)
        {
            _totalScore *= multiply;
        }

        private void ResetScore()
        {
            _totalScore = 0;
            UpdateUIScore(0);
        }

        private void AddScorePolish(int val)
        {
            _polishController.AddScorePolish(val);
        }

        private void AddScore(int val)
        {
            _totalScore += val;
        }

        private void UpdateUIScore(int val)
        {
            InLevelCanvasController.Instance.UpdateScore(_totalScore);
        }

        private void UpdateEndUIScore(int val)
        {
            LevelCompleteCanvasController.Instance.Score.text = _totalScore.ToString();
        }
    }
}
