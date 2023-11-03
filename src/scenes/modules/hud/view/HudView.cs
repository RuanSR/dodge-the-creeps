using Godot;
using DodgeTheCreeps.src.scenes.modules.hud.presenter;

namespace DodgeTheCreeps.src.scenes.modules.hud.view
{
    public class HudView : CanvasLayer
    {
        [Signal]
        public delegate void StartGame();

        private HudPresenter _presenter;

        public override void _Ready()
        {
            _presenter = new HudPresenter(this);
            // Connect("pressed", this, nameof(OnStartButtonPressed));
            // Connect("pressed", this, nameof(OnStartButtonPressed));
        }

        public void ShowMessage(string text)
        {
            _presenter.ShowMessage(text);
            _presenter.StartMessageTimer();
        }

        async public void ShowGameOver()
        {
            await _presenter.ShowGameOver();
        }

        public void UpdateScore(int score)
        {
            _presenter.UpdateScore(score);
        }

        public void OnMessageTimerTimeout()
        {
            _presenter.MessageHide();
        }

        public void OnStartButtonPressed()
        {
            _presenter.HideStartButton();
            EmitSignal(nameof(StartGame));
        }
    }

}
