using Godot;
using DodgeTheCreeps.src.scenes.modules.hud.view;
using DodgeTheCreeps.src.scenes.modules.player.view;
using DodgeTheCreeps.src.scenes.levels.MainLevel.View;

namespace DodgeTheCreeps.src.scenes.levels.MainLevel.Model
{
    public class MainLevelModel
    {
        private readonly ColorRect _colorRect;
        private readonly Timer _mobTimer;
        private readonly Timer _scoreTimer;
        private readonly Timer _startTimer;
        private readonly Position2D _startPosition;
        private readonly AudioStreamPlayer _audioStreamMusic;
        private readonly AudioStreamPlayer _audioStreamDeadAudio;
        public MobPath MobPath { get; }
        public HudView HudView { get; }
        public PlayerView PlayerView { get; }
        public int Score { get; private set; }

        public MainLevelModel(
            ColorRect colorRect, Timer mobTimer, Timer scoreTimer,
            Timer startTimer, Position2D startPosition, AudioStreamPlayer audioStreamMusic,
            AudioStreamPlayer audioStreamDeadAudio, HudView hudView, PlayerView playerView, MobPath mobPath
            )
        {
            _colorRect = colorRect;
            _mobTimer = mobTimer;
            _scoreTimer = scoreTimer;
            _startTimer = startTimer;
            _startPosition = startPosition;
            _audioStreamMusic = audioStreamMusic;
            _audioStreamDeadAudio = audioStreamDeadAudio;
            MobPath = mobPath;
            HudView = hudView;
            PlayerView = playerView;
        }

        public Vector2 GetStartPosition()
        {
            return _startPosition.Position;
        }
        public void ScoredPoint() { Score++; }
        public void ResetScore() { Score = 0; }
        public void StopMobTimer() { _mobTimer.Stop(); }
        public void StartMobTimer() { _mobTimer.Start(); }
        public void StopScoreTimer() { _scoreTimer.Stop(); }
        public void StartScoreTimer() { _scoreTimer.Start(); }
        public void StartStartTimer() { _startTimer.Start(); }
        public void StopStartTimer() { _startTimer.Stop(); }
        public void PlayAudioStreamMuic()
        {
            _audioStreamMusic.Play();
        }

        public void StopAudioStreamMuic()
        {
            _audioStreamMusic.Stop();
        }

        public void PlayAudioStreamDeadAudio()
        {
            _audioStreamDeadAudio.Play();
        }

        public void ConnectSignals(MainLevelView view)
        {
            HudView.Connect("StartGame", view, nameof(view.NewGame));
            PlayerView.Connect("Hit", view, nameof(view.GameOver));
            _startTimer.Connect("timeout", view, nameof(view.OnStartTimerTimeout));
            _scoreTimer.Connect("timeout", view, nameof(view.OnScoreTimerTimeout));
            _mobTimer.Connect("timeout", view, nameof(view.OnMobTimerTimeout));
        }
    }
}