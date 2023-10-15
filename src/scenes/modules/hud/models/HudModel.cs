using Godot;

namespace DodgeTheCreeps.src.scenes.modules.hud.models
{
    public class HudModel
    {
        public readonly Timer MessageTimer;

        private readonly Label _scoreLabel;
        private readonly Label _message;
        private readonly Button _startButton;


        public HudModel(Label scoreLabel, Label message, Button startButton, Timer messageTimer)
        {
            _scoreLabel = scoreLabel;
            _message = message;
            _startButton = startButton;
            MessageTimer = messageTimer;
        }

        public void ShowMessageLabel()
        {
            _message.Show();
        }

        public void HideMessageLabel()
        {
            _message.Hide();
        }

        public void SetTextMessageLabel(string text)
        {
            _message.Text = text;
        }

        public void ShowStartButton()
        {
            _startButton.Show();
        }

        public void HideStartButton()
        {
            _startButton.Hide();
        }

        public void UpdateScoreLabel(int score)
        {
            _scoreLabel.Text = score.ToString();
        }

    }
}