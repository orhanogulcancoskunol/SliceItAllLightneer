using System;
using _game.Scripts.Obstacles;
using TMPro;
using UnityEngine;

namespace _game.Scripts
{
    public class ScoreEffectController : MonoBehaviour
    {
        private TextMeshProUGUI _score;

        private void Awake()
        {
            _score = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void UpdateScore(int val)
        {
            _score.text = "+" + val;
        }
        
        private void FixedUpdate()
        {
            transform.position += Vector3.up * Time.fixedDeltaTime;
        }
    }
}
