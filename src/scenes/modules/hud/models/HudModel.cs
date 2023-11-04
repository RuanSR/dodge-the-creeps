using Godot;
using DodgeTheCreeps.src.Scenes.Modules.Hud.View;

namespace DodgeTheCreeps.src.Scenes.Modules.Hud.Models
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

        public void ConnectSignals(HudView view)
        {
            _startButton.Connect("pressed", view, nameof(view.OnStartButtonPressed));
            MessageTimer.Connect("timeout", view, nameof(view.OnMessageTimerTimeout));
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