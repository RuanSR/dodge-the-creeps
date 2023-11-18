using Godot;
using DodgeTheCreeps.src.Scenes.Levels.MainLevel.Model;
using DodgeTheCreeps.src.Scenes.Levels.MainLevel.View;
using DodgeTheCreeps.src.Scenes.Modules.Enemy.Mob.View;
using DodgeTheCreeps.src.Scenes.Modules.Hud.View;
using DodgeTheCreeps.src.Scenes.Modules.Player.View;
using DodgeTheCreeps.src.Scenes.Shared;

namespace DodgeTheCreeps.src.Scenes.Levels.MainLevel.Presenter
{
    public class MainLevelPresenter
    {
        private readonly MainLevelView _view;
        private readonly MainLevelModel levelModel;

        public MainLevelPresenter(MainLevelView view)
        {
            _view = view;

            var playerView = _view.LoadAndInstance<PlayerView>("res://src/scenes/modules/player/view/Player.tscn");
            var hudView = _view.LoadAndInstance<HudView>("res://src/scenes/modules/hud/view/HUD.tscn");

            levelModel = new MainLevelModel(
                _view.GetNode<ColorRect>("ColorRect"), _view.GetNode<Timer>("MobTimer"),
                _view.GetNode<Timer>("ScoreTimer"), _view.GetNode<Timer>("StartTimer"),
                _view.GetNode<Position2D>("StartPosition"), _view.GetNode<AudioStreamPlayer>("Music"),
                _view.GetNode<AudioStreamPlayer>("DeadAudio"), hudView,
                playerView, (MobPathModel)_view.GetNode<Path2D>("MobPath"));

            levelModel.ConnectSignals(_view);
        }

        public void GameOver()
        {
            levelModel.StopMobTimer();
            levelModel.StopScoreTimer();
            levelModel.HudView.ShowGameOver();
            levelModel.PlayAudioStreamDeadAudio();
            levelModel.StopAudioStreamMuic();
        }

        public void NewGame()
        {
            levelModel.ResetScore();

            levelModel.PlayerView.Start(levelModel.GetStartPosition());

            levelModel.StartStartTimer();

            levelModel.HudView.UpdateScore(levelModel.Score);

            levelModel.HudView.ShowMessage("Get Ready!");

            _view.GetTree().CallGroup("mobs", "queue_free");

            levelModel.PlayAudioStreamMuic();

        }

        public void OnScoreTimerTimeout()
        {
            levelModel.ScoredPoint();
            levelModel.HudView.UpdateScore(levelModel.Score);
        }

        public void OnStartTimerTimeout()
        {
            levelModel.StartMobTimer();
            levelModel.StartScoreTimer();
        }

        public void OnMobTimerTimeout()
        {
            // Note: Normally it is best to use explicit types rather than the `var`
            // keyword. However, var is acceptable to use here because the types are
            // obviously Mob and PathFollow2D, since they appear later on the line.

            // Create a new instance of the Mob scene.
            var mob = (MobView)_view.MobScene.Instance();

            // Choose a random location on Path2D.
            // var mobSpawnLocation = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
            var mobSpawnLocation = levelModel.MobPath.MobSpawnLocation;
            // var mobSpawnLocation = levelModel.MobSpawnLocation;

            mobSpawnLocation.Offset = GD.Randi();

            // Set the mob's direction perpendicular to the path direction.
            float direction = mobSpawnLocation.Rotation + Mathf.Pi / 2;

            // Set the mob's position to a random location.
            mob.Position = mobSpawnLocation.Position;

            // Add some randomness to the direction.
            direction += (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
            mob.Rotation = direction;

            // Choose the velocity.
            var velocity = new Vector2((float)GD.RandRange(150.0, 250.0), 0);
            mob.LinearVelocity = velocity.Rotated(direction);

            // Spawn the mob by adding it to the Main scene.
            _view.AddChild(mob);
        }
    }
}