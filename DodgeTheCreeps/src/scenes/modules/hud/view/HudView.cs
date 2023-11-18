using Godot;
using DodgeTheCreeps.src.Scenes.Modules.Hud.Presenter;

namespace DodgeTheCreeps.src.Scenes.Modules.Hud.View
{
    public class HudView : CanvasLayer
    {
        [Signal]
        public delegate void StartGame();

        private HudPresenter _presenter;

        public override void _Ready()
        {
            _presenter = new HudPresenter(this);
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
