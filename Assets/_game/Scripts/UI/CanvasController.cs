using _game.Scripts.Utilities;
using UnityEngine;

namespace _game.Scripts.UI
{
    public class CanvasController<T> : Singleton<T> where T : MonoBehaviour
    {
        private Canvas _canvas;
        private CanvasGroup _canvasGroup;

        protected override void Awake()
        {
            base.Awake();
            _canvas = GetComponent<Canvas>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Show()
        {
            _canvas.enabled = true;
            _canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            _canvas.enabled = false;
            _canvasGroup.alpha = 0;
        }

    }
}
