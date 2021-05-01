using System;
using UnityEngine;

namespace _game.Scripts.Character
{
    public class SwordScoreController : MonoBehaviour
    {
        public delegate void OnHit(int num);

        public OnHit OnObstacle, OnGround, OnEndLevel;

        public void ScoreMultiply(int multiply)
        {
            
        }
    }
}
