using UnityEngine;

namespace _game.Scripts
{
    public class WindEffect : MonoBehaviour
    {
        public GameObject[] Effects;

        public void Activate(bool active)
        {
            foreach (var effect in Effects)
            {
                effect.SetActive(active);
            }}
    }
}
