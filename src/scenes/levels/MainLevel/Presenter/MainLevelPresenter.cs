using Godot;
using DodgeTheCreeps.src.scenes.levels.MainLevel.Model;
using DodgeTheCreeps.src.scenes.levels.MainLevel.View;
using DodgeTheCreeps.src.scenes.modules.enemy.mob.view;
using DodgeTheCreeps.src.scenes.modules.hud.view;
using DodgeTheCreeps.src.scenes.modules.player.view;

namespace DodgeTheCreeps.src.scenes.levels.MainLevel.Presenter
{
    public class MainLevelPresenter
    {
        private readonly MainLevelView _view;
        private readonly MainLevelModel levelModel;

        public MainLevelPresenter(MainLevelView view)
        {
            _view = view;
            levelModel = new MainLevelModel(
                _view.GetNode<ColorRect>("ColorRect"), _view.GetNode<Timer>("MobTimer"),
                _view.GetNode<Timer>("ScoreTimer"), _view.GetNode<Timer>("StartTimer"),
                _view.GetNode<Position2D>("StartPosition"), _view.GetNode<AudioStreamPlayer>("Music"),
                _view.GetNode<AudioStreamPlayer>("DeadAudio"), _view.GetNode<HudView>("HUD"),
                _view.GetNode<PlayerView>("Player"), (MobPath)_view.GetNode<Path2D>("MobPath"));
        }

        public void GameOver()
        {
            levelModel.MobTimer.Stop();
            levelModel.ScoreTimer.Stop();
            levelModel.HudView.ShowGameOver();
            levelModel.AudioStreamDeadAudio.Play();
            levelModel.AudioStreamMusic.Stop();
        }

        public void NewGame()
        {
            levelModel.Score = 0;

            levelModel.PlayerView.Start(levelModel.StartPosition.Position);

            levelModel.StartTimer.Start();

            levelModel.HudView.UpdateScore(levelModel.Score);

            levelModel.HudView.ShowMessage("Get Ready!");

            _view.GetTree().CallGroup("mobs", "queue_free");

            levelModel.AudioStreamMusic.Play();

        }

        public void OnScoreTimerTimeout()
        {
            levelModel.Score++;
            levelModel.HudView.UpdateScore(levelModel.Score);
        }

        public void OnStartTimerTimeout()
        {
            levelModel.MobTimer.Start();
            levelModel.ScoreTimer.Start();
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