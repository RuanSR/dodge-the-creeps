using Godot;
using System.Threading.Tasks;
using DodgeTheCreeps.src.Scenes.Modules.Hud.Models;
using DodgeTheCreeps.src.Scenes.Modules.Hud.View;

namespace DodgeTheCreeps.src.Scenes.Modules.Hud.Presenter
{
    public class HudPresenter
    {
        private readonly HudView _view;
        private readonly HudModel HudModel;

        public HudPresenter(HudView view)
        {
            _view = view;

            HudModel = new HudModel(
            _view.GetNode<Label>("ScoreLabel"), _view.GetNode<Label>("Message"),
            _view.GetNode<Button>("StartButton"), _view.GetNode<Timer>("MessageTimer"));

            HudModel.ConnectSignals(_view);
        }

        public void ShowMessage(string text)
        {
            HudModel.SetTextMessageLabel(text);
            MessageShow();
        }

        public void StartMessageTimer()
        {
            HudModel.MessageTimer.Start();
        }

        public async Task ShowGameOver()
        {
            ShowMessage("Game Over");

            await _view.ToSignal(HudModel.MessageTimer, "timeout");

            HudModel.MessageTimer.Stop();

            HudModel.SetTextMessageLabel("Dodge the\nCreeps!");
            HudModel.ShowMessageLabel();

            await _view.ToSignal(_view.GetTree().CreateTimer(1), "timeout");
            HudModel.ShowStartButton();
        }

        public void MessageShow()
        {
            HudModel.ShowMessageLabel();
        }

        public void MessageHide()
        {
            HudModel.HideMessageLabel();
        }

        public void HideStartButton()
        {
            HudModel.HideStartButton();
        }

        internal void UpdateScore(int score)
        {
            HudModel.UpdateScoreLabel(score);
        }
    }
}