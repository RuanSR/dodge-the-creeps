using Godot;
using DodgeTheCreeps.src.scenes.levels.MainLevel.Presenter;

namespace DodgeTheCreeps.src.scenes.levels.MainLevel.View
{
    public class MainLevelView : Node
    {
        [Export]
        public PackedScene MobScene;

        private MainLevelPresenter _mainLevelPresenter;

        public override void _Ready()
        {
            GD.Randomize();

            _mainLevelPresenter = new MainLevelPresenter(this);
        }

        public void GameOver()
        {
            _mainLevelPresenter.GameOver();
        }

        public void NewGame()
        {
            _mainLevelPresenter.NewGame();
        }

        public void OnScoreTimerTimeout()
        {
            _mainLevelPresenter.OnScoreTimerTimeout();
        }

        public void OnStartTimerTimeout()
        {
            _mainLevelPresenter.OnStartTimerTimeout();
        }

        public void OnMobTimerTimeout()
        {
            _mainLevelPresenter.OnMobTimerTimeout();
        }

    }
}