using TMPro;

namespace _game.Scripts.UI
{
    public class InLevelCanvasController : CanvasController<InLevelCanvasController>
    {
        public TextMeshProUGUI ScoreValue;

        public void UpdateScore(int val)
        {
            ScoreValue.text = val.ToString();
        }
    }
}
